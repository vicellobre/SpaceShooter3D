using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rgbd;
    [SerializeField]
    private float tumble;

    private void Start() {
        // Velocidad aleatoria en la Rotacion
        rgbd.angularVelocity = Random.insideUnitSphere * tumble;
    }
}
