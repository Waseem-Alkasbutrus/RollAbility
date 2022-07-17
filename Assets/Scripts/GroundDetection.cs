using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetection : MonoBehaviour
{
    private PlayerController playerController;

    public float groundFriction;
    public float iceFriction;
    public float mudFriction;

    public float groundSpeed;
    public float iceSpeed;
    public float mudSpeed;

    private void Start() {
        playerController = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    private void OnTriggerStay2D(Collider2D other) {
        if (other.tag == "Ground" || other.tag == "Mud" || other.tag == "Ice") {
            playerController.isGrounded = true;
            
            switch (other.tag)
            {
                case "Ground":
                    playerController.friction = groundFriction;
                    playerController.movementSpeed = groundSpeed;
                    break;
                case "Mud":
                    playerController.friction = mudFriction;
                    playerController.movementSpeed = mudSpeed;
                    break;
                case "Ice":
                    playerController.friction = iceFriction;
                    playerController.movementSpeed = iceSpeed;
                    break;
                default:
                    Debug.Log("Unknown material");
                    break;
            }
        }

    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Ground" || other.tag == "Mud" || other.tag == "Ice") {
            playerController.isGrounded = false;
        }
    }
}
