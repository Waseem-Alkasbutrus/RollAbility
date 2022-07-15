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

    // [HideInInspector]
    public bool isGrounded;

    private float movement;
    private Rigidbody2D rigidbody;

    private void Start() {
        rigidbody = GetComponent<Rigidbody2D>();
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
    }

    private void FixedUpdate() {
        rigidbody.velocity = new Vector2(movementSpeed * movement, rigidbody.velocity.y);
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
        rigidbody.velocity = new Vector2(rigidbody.velocity.x, flapForce);
    }

    private void Jump() {
        if (isGrounded) {
            Debug.Log("Jump");
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpForce);
        }
    }

    private void Thrust() {
        Debug.Log("Thrust JetPack");
        rigidbody.AddForce(Vector2.up * thrustForce);
    }
}
