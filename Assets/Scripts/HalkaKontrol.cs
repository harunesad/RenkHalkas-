using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalkaKontrol : MonoBehaviour
{
    public float rotateSpeed;
    public bool leftRotate = true;
    private void FixedUpdate()
    {
        if (leftRotate)
        {
            transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
        }
        else
        {
            transform.Rotate(0, 0, -rotateSpeed * Time.deltaTime);
        }
    }
}
