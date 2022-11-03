using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    void Update()
    {
        //mouse position x 
        float mouseX = Input.GetAxis("Mouse X");
        //mouse position y
        float mouseY = Input.GetAxis("Mouse Y");

        //rotate camera on x axis
        transform.Rotate(0, mouseX, 0);
    }
}
