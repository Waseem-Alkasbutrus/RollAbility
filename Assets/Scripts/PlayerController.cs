using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public enum MovementType {Jump, Sling, JetPack, Flap}

    public MovementType movementType;
    public float movementSpeed;
    public float jumpForce;
    public float thrustForce;
    public float flapForce;
    public float slingForce;
    public Vector2 maxSlingDist;

    // [HideInInspector]
    public bool isGrounded;

    private float movement;
    private Rigidbody2D rb;
    public Camera mainCamera;

    private Vector2 SlingStartPos;
    private Vector2 SlingEndPos;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
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

        if(movementType == MovementType.JetPack && Input.GetAxisRaw("Vertical") > 0) {
            Thrust();
        }

        if(movementType == MovementType.Sling && Input.GetMouseButtonDown(0)) {
            SlingStartPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log("Mouse Down");
        }

        if(movementType == MovementType.Sling && Input.GetMouseButtonUp(0)) {
            SlingEndPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log("Mouse Up");
            Sling();
        }
    }

    private void FixedUpdate() {
        if (movementType != MovementType.Sling) {
            rb.AddForce(new Vector2(movement, 0) * movementSpeed);
        }
    }

    private void Up() {
        switch (movementType)
        {
            case MovementType.Jump:
                Jump();
                break;
            case MovementType.Sling: Debug.Log("Sling");
                break;
            case MovementType.JetPack: Debug.Log("Thrust JetPack");
                Thrust();
                break;
            case MovementType.Flap: Debug.Log("Flap");
                Flap();
                break;
            default: Debug.Log("CHECK MOVEMENT TYPES");
                break;
        }
    }

    private void Flap() {
        Debug.Log("Flap");
        rb.velocity = new Vector2(rb.velocity.x, flapForce);
    }

    private void Jump() {
        if (isGrounded) {
            Debug.Log("Jump");
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    private void Thrust() {
        Debug.Log("Thrust JetPack");
        rb.AddForce(Vector2.up * thrustForce);
    }

    private void Sling() {
        Vector2 force = new Vector2(Mathf.Clamp(SlingStartPos.x - SlingEndPos.x, -maxSlingDist.x, maxSlingDist.x), Mathf.Clamp(SlingStartPos.y - SlingEndPos.y, -maxSlingDist.y, maxSlingDist.y));
        rb.AddForce(force * slingForce, ForceMode2D.Impulse);

        Debug.Log(force * slingForce);
    }
}
