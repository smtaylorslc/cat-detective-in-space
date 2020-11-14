using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Cat;

    void FixedUpdate()
    {
        transform.position = new Vector3(Cat.position.x, Cat.position.y);
    }
}
