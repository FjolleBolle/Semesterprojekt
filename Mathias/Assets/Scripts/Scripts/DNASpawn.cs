using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DNASpawn : MonoBehaviour
{
    public string PlatformTag = "Platform";

    private GameObject[] allEggs = new GameObject[3];
    private GameObject spawnArea;
    private float spawnArea_halfWidth, spawnArea_halfDepth;

    [HideInInspector]
    public static int totalEggs = 3;

    private float timeSinceLastEgg;
    [Range(0f, 10f)]
    public float minTimeBetweenEggs = 2f, checkRadius = 1f;
    private bool isCoroutineRunning = false;

    void Start()

    {
        //get the children of the spawn area
        for (int i = 0; i < allEggs.Length; i++)
        {
            allEggs[i] = gameObject.transform.GetChild(i).gameObject;
            allEggs[i].SetActive(false);
        }

        //assign gameobj the script is attached to as spawn area
        spawnArea = gameObject;

        //get the width and depth of the spawn area

        spawnArea_halfWidth = (spawnArea.GetComponent<Collider>().bounds.size.x) / 2;
        spawnArea_halfDepth = (spawnArea.GetComponent<Collider>().bounds.size.y) / 2;
        //spawn the first egg
        StartCoroutine("SpawnAndCheck");
    }
    Vector3 GetRandomPosition()
    {
        Vector3 newPos = new Vector3(Random.Range(-spawnArea_halfWidth, spawnArea_halfWidth), Random.Range(-spawnArea_halfDepth, spawnArea_halfDepth), 0);

        return newPos;
    }

    private bool CheckPositionIsEmpty(Vector3 pos, float radius)
    {
        Collider[] hitColliders = Physics.OverlapSphere(pos, radius);

        for (int j = 0; j < hitColliders.Length; j++)
        {
            if (hitColliders[j].gameObject.CompareTag(PlatformTag))
            {
                return false;
            }
        }
        return true;
    }
    private void MoveAndActivate(GameObject egg, Vector3 newPos)
    {
        egg.transform.localPosition = newPos;
        egg.SetActive(true);

        timeSinceLastEgg = 0f;
        totalEggs++;
    }
    IEnumerator SpawnAndCheck()
    {
        //check if another coroutine is running
        if (isCoroutineRunning)
        {
            //end coroutine if another coroutine is running
            yield break;
        }
        else
        {
            //ensure that no other coroutines can start after this
            isCoroutineRunning = true;
        }
        //wait some time before starting function
        yield return new WaitForSeconds(minTimeBetweenEggs);
        //for each egg that is not active in the hierarchy,

        foreach (GameObject egg in allEggs)
        {
            if (!(egg.activeInHierarchy))
            {
                while (true)
                {
                    Vector3 newPos = GetRandomPosition();
                    if (CheckPositionIsEmpty(newPos, checkRadius))
                    {
                        MoveAndActivate(egg, newPos);
                        break;
                    }
                    yield return null;
                } // end of while
                break;
            }// end of if
            yield return null;
        } //end of foreach
        isCoroutineRunning = false;
        yield return null;
    }// end of coroutine

    void Update()
    {
        //if the total num of eggs in the scene is less than 2 and the last egg spawned minTimeBetweenEggs seconds ago
        if (totalEggs < 3 && timeSinceLastEgg > minTimeBetweenEggs)
        {
            StartCoroutine("SpawnAndCheck");
        }
        //increase the time since the last egg was added
        timeSinceLastEgg += Time.deltaTime;
    }

    /*[SerializeField]
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
            
                Vector3 DNAPosition = new Vector3(Random.Range(-8f, 8f), Random.Range(-4.4f, 4.4f), 0f);
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
    }*/
}
