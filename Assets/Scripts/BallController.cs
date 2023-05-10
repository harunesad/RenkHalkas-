using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    Rigidbody2D rb;
    public float jumpForce = 3;
    bool isClick = false;

    string currentColor;
    public Color ballColor;
    public Color turkuaz, sari, mor, pembe;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        RandomColor();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isClick = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            isClick = false;
        }
    }
    private void FixedUpdate()
    {
        if (isClick)
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.tag);
    }
    void RandomColor()
    {
        int random = Random.Range(0, 4);
        switch (random)
        {
            case 0:
                currentColor = "Turkuaz";
                ballColor = turkuaz;
                break;
            case 1:
                currentColor = "Sari";
                ballColor = sari;
                break;
            case 2:
                currentColor = "Pembe";
                ballColor = pembe;
                break;
            case 3:
                currentColor = "Mor";
                ballColor = mor;
                break;
            default:
                break;
        }

        GetComponent<SpriteRenderer>().color = ballColor;
        Debug.Log(random);
    }
}
