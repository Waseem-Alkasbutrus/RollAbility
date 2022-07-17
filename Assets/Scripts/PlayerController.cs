using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public enum MovementType {Jump, Sling, Flap, JetPack}

    [Space(10)]
    public MovementType movementType;
    public Camera mainCamera;

    [Header("Attributes")]
    public float movementSpeed;
    public float flyForce;
    public float jumpForce;
    public float thrustForce;
    public float flapForce;
    public float slingForce;
    public Vector2 maxSlingDist;

    [Header("Temporary Debug Info")]
    // [HideInInspector]
    public bool isGrounded;
    // [HideInInspector]
    public float friction;

    private float movement;
    private Rigidbody2D rb;
    private DrawSlingLine slingLine;

    private Vector2 SlingStartPos;
    private Vector2 SlingEndPos;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        slingLine = GetComponent<DrawSlingLine>();
    }

    // Update is called once per frame
    private void Update()
    {
        movement = Input.GetAxisRaw("Horizontal");
        
        if(Input.GetButtonDown("Jump")) {
            if (movementType == MovementType.Flap) {
                Flap();
            } else if (movementType == MovementType.Jump) {
                Jump();
            }
        }

        if(movementType == MovementType.JetPack && Input.GetButton("Jump")) {
            Thrust();
        }

        if (movementType == MovementType.Sling) {
            if(Input.GetMouseButtonDown(0)) {
                SlingStartPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            }

            if (Input.GetMouseButton(0)) {
                Vector2 SlingCurrentPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
                slingLine.RenderLine(SlingStartPos, SlingCurrentPos);
            } else {
                slingLine.ClearLine();
            }

            if(movementType == MovementType.Sling && Input.GetMouseButtonUp(0)) {
                SlingEndPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
                Sling();
            }
        }
    }

    private void FixedUpdate() {
        if (!isGrounded && movementType != MovementType.Sling) {
            rb.AddForce(new Vector2(movement/2, 0) * flyForce);
        } else if (movementType != MovementType.Sling) {
            if (movement != 0) {
                rb.velocity = new Vector2(movementSpeed * movement, rb.velocity.y);
            } else {
                rb.velocity = new Vector2(rb.velocity.x * friction, rb.velocity.y);
            }
        } else if (movementType == MovementType.Sling && isGrounded) {
            rb.velocity = new Vector2(rb.velocity.x * friction, rb.velocity.y);
        }
    }

    private void Flap() {
        rb.velocity = new Vector2(rb.velocity.x, flapForce);
    }

    private void Jump() {
        if (isGrounded) {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    private void Thrust() {
        rb.AddForce(Vector2.up * thrustForce);
    }

    private void Sling() {
        if (isGrounded) {
            Vector2 force = new Vector2(Mathf.Clamp(SlingStartPos.x - SlingEndPos.x, -maxSlingDist.x, maxSlingDist.x), Mathf.Clamp(SlingStartPos.y - SlingEndPos.y, -maxSlingDist.y, maxSlingDist.y));
            rb.AddForce(force * slingForce, ForceMode2D.Impulse);
        }
    }

    public void SetMovementMode(int mode) {
        Debug.Log("Rolled a " + mode + "!");
        switch(mode) {
            case 1: 
                movementType = MovementType.Jump;
                break;
            case 2: 
                movementType = MovementType.Sling;
                break;
            case 3: 
                movementType = MovementType.Flap;
                break;
            // case 4: 
            //     movementType = MovementType.JetPack;
            //     break;
            default:
                Debug.Log("Unknown movement type: " + mode);
                break;
        }
    }

    public string GetMovementTypeString() {
        return movementType.ToString();
    }
}
