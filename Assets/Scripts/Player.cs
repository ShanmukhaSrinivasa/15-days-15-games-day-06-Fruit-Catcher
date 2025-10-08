using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement Info")]
    private float xInput;
    private float yInput;
    [SerializeField] private float moveSpeed;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        Vector2 moveDirection = new Vector2(xInput, yInput);

        moveDirection.Normalize();

        rb.linearVelocity = moveDirection * moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Apple")
        {
            GameManager.instance.IncrementScore();
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Banana")
        {
            GameManager.instance.IncrementScore();
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Grapes")
        {
            GameManager.instance.IncrementScore();
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Watermelon")
        {
            GameManager.instance.IncrementScore();
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Bomb")
        {
            GameManager.instance.lives--;
            Destroy(collision.gameObject);
        }
    }

    
}
