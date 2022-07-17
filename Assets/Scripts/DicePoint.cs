using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DicePoint : MonoBehaviour
{
    private GameObject player;
    private DicePointManager respawnManager;

    public int index;

    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0];
        respawnManager = GameObject.FindGameObjectsWithTag("RespawnManager")[0].GetComponent<DicePointManager>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player" && respawnManager.GetNextPoint() == index) {
            // Send position to manager
            respawnManager.SetSpawnPoint(this.gameObject.transform.position);

            // Pick a number between 1-3
            player.GetComponent<PlayerController>().SetMovementMode((int) Random.Range(1f,4f));
            
            // Play roll animation
            
            // Destroy die
            Destroy(this.gameObject);
        }
    }
}
