using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "PlataformaMovible")
        {
            transform.parent = other.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        if (other.gameObject.tag == "PlataformaMovible")
        {
            transform.parent = null;
        }
    }
}
