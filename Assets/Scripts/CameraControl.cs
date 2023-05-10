using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform ball;

    private void LateUpdate()
    {
        if (ball.transform.position.y > transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, ball.transform.position.y, transform.position.z);
        }
    }
}
