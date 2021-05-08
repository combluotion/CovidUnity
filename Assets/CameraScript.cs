using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
public Transform player;

public float cameraSpeed;
 public float cameraBoundXRight;
 public float cameraBoundXLeft;
 public float cameraBoundYUp;
 public float cameraBoundYDown;
    void FixedUpdate()
    { 
 //transform.position = new Vector3 (player.position.x + offset.x, player.position.y + offset.y, offset.z); // Camera follows the player with specified offset position

   Vector3 desiredPosition = new Vector3(Mathf.Clamp(player.position.x, cameraBoundXLeft, cameraBoundXRight),
                                  Mathf.Clamp(player.position.y, cameraBoundYDown, cameraBoundYUp), 
                                  transform.position.z);
  transform.position = Vector3.Lerp(transform.position, desiredPosition,  cameraSpeed);


}

    }


