using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Player1Mov : MonoBehaviour
{
    Rigidbody2D rb;
    public float Speed = 4f;
    public float DefaultSpeed = 4f;
    public float jumpForce = 8f; 
    public bool onGround;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    { 
        if (Input.GetKeyDown(KeyCode.UpArrow) && onGround)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            onGround = false;
        }

        float direction = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(direction, 0f, 0f) * Time.deltaTime * Speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
            onGround = true;
    }

    private void FixedUpdate()
    {
        if (rb.velocity.x > Speed)
            rb.velocity = new Vector2(Speed, rb.velocity.y);
        if (rb.velocity.x < -Speed)
            rb.velocity = new Vector2(-Speed, rb.velocity.y);
    }

    /*public void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);
    }*/
}