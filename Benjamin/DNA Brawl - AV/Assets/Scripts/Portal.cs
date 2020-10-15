using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private Transform destination;

    public bool isOrange;

    public float distance = 0.3f;


    // Start is called before the first frame update
    void Start()
    {
        if (isOrange == false)
        {
            destination = GameObject.FindGameObjectWithTag("OrangePortal").GetComponent<Transform>();
        }
        else
            {
                destination = GameObject.FindGameObjectWithTag("BluePortal").GetComponent<Transform>();
            }
        }

    void OnTriggerEnter2D(Collider2D other2)
    {
        if (Vector2.Distance(transform.position, other2.transform.position) > distance)
        {
            other2.transform.position = new Vector2(destination.position.x, destination.position.y);
        }
    }
}