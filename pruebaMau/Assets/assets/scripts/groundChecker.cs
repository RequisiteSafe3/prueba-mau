using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundChecker : MonoBehaviour
{
    public static bool isGrounded;

    private void OnTriggerEnter2D(Collider2D collision) { // CheckGround.
        isGrounded = true;
    }
    private void OnTriggerExit2D(Collider2D collision) {
        isGrounded = false;
    }
}
