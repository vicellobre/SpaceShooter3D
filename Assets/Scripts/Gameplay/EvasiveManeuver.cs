using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvasiveManeuver : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rgbd;
    [SerializeField]
    private Vector2 startWait, maneuverTime, maneuverWait;
    [SerializeField]
    private float dodge, smoothing;
    private float targetManeuver;

    [SerializeField]
    private Boundary boundary;
    [SerializeField]
    private float tilt; // inclinacion

    private void Start()
    {
        UpdateBoubndary();
        StartCoroutine(Evade());
    }

    private IEnumerator Evade()
    {   // Primera maniobra
        float randomSeconds = Random.Range(startWait.x, startWait.y);
        yield return new WaitForSeconds(randomSeconds);
        
        while (true)
        {
            // Velocidad de maniobra
            targetManeuver = Random.Range(1, dodge) * -Mathf.Sign(transform.position.x);

            // Duracion de la maniobra
            randomSeconds = Random.Range(maneuverTime.x, maneuverTime.y);
            yield return new WaitForSeconds(randomSeconds);
            
            // Detener maiobra
            targetManeuver = 0;

            // Espera para la proxima maniobra
            randomSeconds = Random.Range(maneuverWait.x, maneuverWait.y);
            yield return new WaitForSeconds(randomSeconds);
        }
    }

    private void FixedUpdate() {
        // mueve el valor de la primera variable hacia la segunda variable
        //  auna velocidad de la tercera variable
        float newManeuver = Mathf.MoveTowards(rgbd.velocity.x, targetManeuver, Time.deltaTime * smoothing);
        rgbd.velocity = new Vector3(targetManeuver, 0f, rgbd.velocity.z);

        // Limitar campo de movimiento para la nave
        rgbd.position = new Vector3(
            Mathf.Clamp(rgbd.position.x, boundary.xMin, boundary.xMax),
            0f,
            rgbd.position.z);

        // Animar rotacion
        rgbd.rotation = Quaternion.Euler(0f, 0f, rgbd.velocity.x * -tilt);
    }

    private void UpdateBoubndary(){
        Vector2 half = Utils.GetHalfDimensionsInWorldUnits();

        boundary.xMin = -half.x + 0.9f;
        boundary.xMax = half.x - 0.9f;
        boundary.zMin = 0;
        boundary.zMax = 0;
    }
}
