using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DicePointManager : MonoBehaviour
{
    private GameObject player;
    
    [HideInInspector]
    public Vector3 respawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0];
    }

    public void RespawnPlayer() {
        player.transform.position = respawnPoint;
    }

    public void setSpawnPoint(Vector3 newPosition) {
        respawnPoint = newPosition;
    }
}
