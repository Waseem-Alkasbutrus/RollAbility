using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public enum MovementType {Jump, Sling, JetPack, Flap}

    public MovementType movementType;
    public float movementSpeed;
    public float jumpForce;

    private Vector2 movement;
    private Rigidbody2D rigidbody;

    private void Start() {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate() {
        rigidbody.velocity = new Vector2(movementSpeed * movement.x, rigidbody.velocity.y);
        if (movement.y > 0) {
            Up();
        }
    }

    private void Up() {
        switch (movementType)
        {
            case MovementType.Jump: Debug.Log("Jump");
                break;
            case MovementType.Sling: Debug.Log("Sling");
                break;
            case MovementType.JetPack: Debug.Log("Thrust JetPack");
                Thrust();
                break;
            case MovementType.Flap: Debug.Log("Flap");
                break;
            default: Debug.Log("CHECK MOVEMENT TYPES");
                break;
        }
    }

    private void Thrust() {
        rigidbody.AddForce(Vector2.up * jumpForce);
    }
}
