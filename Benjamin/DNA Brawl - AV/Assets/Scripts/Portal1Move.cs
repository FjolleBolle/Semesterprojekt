using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal1Move : MonoBehaviour
{
    Rigidbody2D rb;
    private float moveSpeed;


    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.transform.position += new Vector3(0, moveSpeed, 0) * Time.deltaTime;

        // Polygon collider is the reference point
        // If the portal gets above this point it starts going the other way (down).
        if (gameObject.transform.position.y > 3.7f)
        {
            moveSpeed = -0.75f;
        }
        
        // If the portal gets below this point it starts going the other way (up).
        if (gameObject.transform.position.y < -3.7f)
        {
            moveSpeed = 0.75f;
        }
    }
}
