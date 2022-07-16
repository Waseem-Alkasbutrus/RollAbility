using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetection : MonoBehaviour
{
    private PlayerController playerController;

    private void Start() {
        playerController = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Ground") {
            Debug.Log("Touched Ground");
            playerController.isGrounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Ground") {
            Debug.Log("Left Ground");
            playerController.isGrounded = false;
        }
    }
}
