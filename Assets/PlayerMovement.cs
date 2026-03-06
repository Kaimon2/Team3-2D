using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 1f;
    private Rigidbody2D rb;
    private Vector2 movement;
    private bool isGrounded;
    public GameObject coin;
    public GameObject exit;
    public TextMeshProUGUI Treasure;
    public TextMeshProUGUI Lives;
    private int treasure = 0;
    private int lives = 3;
    public Vector2 spawnPoint;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        exit.SetActive(false);
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) 
        { 
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce); 
        }

        if(treasure == 10)
        {
            exit.SetActive(true);
        }
        
        if (lives == 0)
        {
            SceneManager.LoadScene("Lose");
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(movement.x * moveSpeed, rb.linearVelocity.y);
    }

    void OnCollisionEnter2D(Collision2D collision) 
    { 
        if (collision.collider.CompareTag("Ground")) 
            isGrounded = true; 
    }
    void OnCollisionExit2D(Collision2D collision) 
    { 
        if (collision.collider.CompareTag("Ground")) 
            isGrounded = false; 
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    { 
        if (collision.CompareTag("Coin")) 
        { 
            Destroy(collision.gameObject);
            treasure++;
            Treasure.text = "Treasure = " + treasure;
        }

        if (collision.CompareTag("Lava"))
        {
            rb.position = spawnPoint; 
            rb.linearVelocity = Vector2.zero;
            lives--;
            Lives.text = "Lives = " + lives;
        }

        if (collision.CompareTag("Exit"))
        {
            SceneManager.LoadScene("Win");
        }
    }
}
