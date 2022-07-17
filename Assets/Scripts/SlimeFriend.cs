using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeFriend : MonoBehaviour
{
    public Animator animator;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            animator.SetBool("EndOfLevel", true);
        }
    }
}
