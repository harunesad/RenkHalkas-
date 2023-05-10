using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    Rigidbody2D rb;
    public float jumpForce = 3;
    bool isClick = false;

    string currentColor;
    public Color ballColor;
    public Color turkuaz, sari, mor, pembe;

    [SerializeField] Text scoreText;
    int score;
    [SerializeField] GameObject halka, renkTekeri;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        scoreText.text = "Score:" + score;
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
        if (collision.tag == "RenkTekeri")
        {
            RandomColor();
            Destroy(collision.gameObject);
            return;
        }
        if (collision.tag != currentColor && collision.tag != "PointInc" && collision.tag != "RenkTekeri")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (collision.tag == "PointInc")
        {
            score += 5;
            scoreText.text = "Score: " + score;
            Destroy(collision.gameObject);

            Instantiate(halka, new Vector3(transform.position.x, transform.position.y + 8, transform.position.z), Quaternion.identity);
            Instantiate(renkTekeri, new Vector3(transform.position.x, transform.position.y + 8, transform.position.z), Quaternion.identity);
        }
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
