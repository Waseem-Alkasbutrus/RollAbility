using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetection : MonoBehaviour
{
    [Space(10)]
    public PlayerController playerController;

    [Header("Ground Physics Attributes")]
    public float groundFriction;
    public float groundSpeed;

    [Header("Ice Physics Attributes")]
    public float iceFriction;
    public float iceSpeed;

    [Header("Mud Physics Attributes")]
    public float mudFriction;
    public float mudSpeed;

    private void Start() {
        Debug.Log(playerController);
    }

    // Update is called once per frame
    private void OnTriggerStay2D(Collider2D other) {
        if (other.tag == "Wall" || other.tag == "MuddyWall" || other.tag == "Ice") {
            playerController.isGrounded = true;
            
            switch (other.tag)
            {
                case "Wall":
                    playerController.friction = groundFriction;
                    playerController.movementSpeed = groundSpeed;
                    break;
                case "MuddyWall":
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
        if (other.tag == "Wall" || other.tag == "MuddyWall" || other.tag == "Ice") {
            playerController.isGrounded = false;
        }
    }
}
