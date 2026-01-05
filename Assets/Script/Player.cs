using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed = 1;
    public float jumpForce = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        
        rb.linearVelocityX = h * moveSpeed;
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        rb.AddForceY(1 * jumpForce);
    }
}
