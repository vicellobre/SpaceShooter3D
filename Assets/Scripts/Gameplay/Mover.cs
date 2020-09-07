using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rgbd;

    [SerializeField]
    private float speed;

    private void Start() {
        rgbd.velocity = transform.forward * speed;
    }
}