using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isGrounded : MonoBehaviour
{
    public static bool value;
    private void OnTriggerEnter2D(Collider2D other) {
        value = true;
    }
private void OnTriggerExit2D(Collider2D other) {
    value=false;
}
}
