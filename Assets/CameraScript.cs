using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject SimonPlayer;
    void Update()
    {
        Vector3 position = transform.position;
        position.x = SimonPlayer.transform.position.x;
        transform.position = position;

    }
}
