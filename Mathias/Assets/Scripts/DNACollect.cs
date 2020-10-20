using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DNACollect : MonoBehaviour
{
    [Range(0f, 20f)] public int numEggsToWin = 5;

    [HideInInspector] public static int eggsCollected = 0;

    [SerializeField] public GameObject door;
    [SerializeField] public Vector3 doorFinalPos;

    public bool hasCoroutineRun = false;
    public void CollectEgg(GameObject eggObject)
    {
        //disable eggObject in hierarchy
        eggObject.SetActive(false);

        //remove egg from total eggs active count
        DNASpawn.totalEggs--;

        //increase egg count
        eggsCollected++;
        Debug.Log("eggs collected: " +eggsCollected);
    }
}
