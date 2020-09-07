using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField]
    private Rigidbody rgbd;

    [SerializeField]
    private Boundary boundary;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float tilt;

    [Header("Shooting")]
    [SerializeField]
    private GameObject shot;
    [SerializeField]
    private Transform shotSpawn;
    [SerializeField]
    private float fireRate;
    private float nextFire;

    private void Start() {
        UpdateBoubndary();
    }

    private void UpdateBoubndary(){
        Vector2 half = Utils.GetHalfDimensionsInWorldUnits();

        boundary.xMin = -half.x + 0.7f;
        boundary.xMax = half.x - 0.7f;
        boundary.zMin = -half.y + 6;
        boundary.zMax = half.y - 2;
    }

    private void Update()
    {
        if (CrossPlatformInputManager.GetButton("Fire1") && Time.time > nextFire)
        {
            Instantiate(shot, shotSpawn.position, Quaternion.identity);
            AudioManager.Play(AudioClipName.Weapon_Player);
            nextFire = Time.time + fireRate;
        }
    }

    private void FixedUpdate()
    {   // Entrada por teclado
        float moveHorizontal = CrossPlatformInputManager.GetAxis("Horizontal");
        float moveVertical = CrossPlatformInputManager.GetAxis("Vertical");

        // Asignacion de velocidad para la nave
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        rgbd.velocity = movement * speed;

        // Limitar campo de movimiento para la nave
        rgbd.position = new Vector3(
            Mathf.Clamp(rgbd.position.x, boundary.xMin, boundary.xMax),
            0f,
            Mathf.Clamp(rgbd.position.z, -1, boundary.zMax));

        // Animar rotacion
        rgbd.rotation = Quaternion.Euler(0f, 0f, rgbd.velocity.x * -tilt);
    }
}