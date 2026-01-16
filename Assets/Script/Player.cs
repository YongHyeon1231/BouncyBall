using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed = 1;
    public float jumpForce = 1;
    public GameObject panel;

    public List<GameObject> stars = new List<GameObject>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        // float v = Input.GetAxis("Vertical");
        
        // rb.linearVelocity = new Vector2(h, v);

        rb.linearVelocityX = h * moveSpeed;


        
        if (transform.position.y < -10)
        {
            rb.linearVelocity = Vector2.zero;
            transform.position = new Vector3(-5.26f, 7.75f, 0);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("obstacle"))
        {
            print("Game Over");
            transform.position = new Vector3(-5.26f, 7.75f, 0);
        } else if(collision.gameObject.CompareTag("Finish"))
        {
            int index = Array.IndexOf(stars.ToArray(), collision.gameObject);

            stars.Remove(stars[index]);
            Destroy(collision.gameObject);

            if(stars.Count == 0)
            {
                Time.timeScale = 0;
                panel.SetActive(true);
                panel.GetComponentInChildren<TextMeshProUGUI>().text = "Game Clear!";
                print("Game Clear");
            }
        } else
        {
            rb.AddForceY(1 * jumpForce);
        }
    }
}
