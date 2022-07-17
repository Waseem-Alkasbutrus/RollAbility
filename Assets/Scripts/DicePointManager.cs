using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DicePointManager : MonoBehaviour
{
    [HideInInspector]
    public Vector3 respawnPoint;

    private GameObject player;
    private int activePointIndex;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0];
        activePointIndex = 0;
    }

    public void RespawnPlayer() {
        player.transform.position = respawnPoint;
    }

    public void SetSpawnPoint(Vector3 newPosition) {
        respawnPoint = newPosition;
        activePointIndex++;
    }

    public int GetNextPoint() {
        return activePointIndex;
    }
}
