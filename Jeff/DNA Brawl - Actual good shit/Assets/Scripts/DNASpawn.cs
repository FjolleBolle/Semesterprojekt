using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DNASpawn : MonoBehaviour
{
    [SerializeField]
    public GameObject DNA;

    public void OnTriggerEnter2D(Collider2D other)
    {
        SpawnDNA();
    }

    public void SpawnDNA()
    {
        bool DNASpawned = false;
        while (!DNASpawned)
        {
            Vector3 DNAPosition = new Vector3(Random.Range(-8f, 8f), Random.Range(-4f, 4f), 0f);
            if ((DNAPosition - transform.position).magnitude < 3)
            {
                continue;
            }
            else
            {
                Instantiate(DNA, DNAPosition, Quaternion.identity);
                DNASpawned = true;
            }
        }

    }
}
