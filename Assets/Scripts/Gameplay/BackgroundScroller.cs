using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [Range(-1f, 0f)]
    [SerializeField]
    private float scrollSpeed;
    private float tileSize;
    private Vector3 startPosition;

    private void Start() {
        startPosition = transform.position;
        tileSize = transform.localScale.y;
    }

    private void Update() {
        // Esto me da un valor entre 0 y tileSize = 34
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSize);
        transform.position = startPosition + Vector3.forward * newPosition;
    }



}
