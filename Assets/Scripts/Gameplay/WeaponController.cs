using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField]
    private GameObject shot;
    [SerializeField]
    private Transform shotSpawn;
    [SerializeField]
    private float delay, fireRate;

    private void Start() {
        // Desde que se llama, espera DELAY en tiempo
        // Despues de la primera vez, espera FIRERATE en tiempo
        InvokeRepeating("Fire", delay, fireRate);
    }

    private void Fire()
    {
        Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        AudioManager.Play(AudioClipName.Weapon_Enemy);
    }
}
