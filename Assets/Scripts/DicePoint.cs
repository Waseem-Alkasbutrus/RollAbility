using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DicePoint : MonoBehaviour
{
    private GameObject player;
    private DicePointManager respawnManager;

    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0];
        respawnManager = GameObject.FindGameObjectsWithTag("RespawnManager")[0].GetComponent<DicePointManager>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            Debug.Log("Checkpoint activated");
            // Send position to manager
            respawnManager.setSpawnPoint(this.gameObject.transform.position);

            // Pick a number between 1-4
            player.GetComponent<PlayerController>().SetMovementMode((int) Random.Range(1f,5f));
            
            // Play roll animation
            
            // Destroy die
            Destroy(this.gameObject);
        }
    }
}
