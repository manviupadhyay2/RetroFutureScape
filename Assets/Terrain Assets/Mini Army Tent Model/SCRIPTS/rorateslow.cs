using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rorateslow : MonoBehaviour
{
    public float rotationSpeed = 2.0f;

    void Update()
    {
        Vector3 rot = transform.eulerAngles;
        transform.rotation = Quaternion.Euler(rot.x, rot.y + Time.deltaTime * rotationSpeed, rot.z);

    }
}
