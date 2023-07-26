
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TirdPersonalCamera : MonoBehaviour
{
    public float rotationSpeed;


    private void Update()
    {
        // ”правление взгл€дом камеры с помощью поворота мыши
        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(Vector3.up * mouseX * rotationSpeed);


    }
}
