using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    [SerializeField]
    private GameObject explotion, playerExplotion;
    private GameController gameController;
    [SerializeField]
    private int scoreValue;

    private void Awake() {
        GameObject go = GameObject.FindGameObjectWithTag("GameController");
        gameController = go.GetComponent<GameController>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Boundary") || other.CompareTag("Enemy")) return;
        // Explosiones
        if (explotion != null)
            Instantiate(explotion, transform.position, Quaternion.identity);
        
        if (other.CompareTag("Player")){
            Instantiate(playerExplotion, other.transform.position, Quaternion.identity);
            gameController.GameOver();
        } else
            gameController.AddScore(scoreValue);
        // Destrucciones
        Destroy(other.gameObject);
        Destroy(gameObject);
        
    }
}
