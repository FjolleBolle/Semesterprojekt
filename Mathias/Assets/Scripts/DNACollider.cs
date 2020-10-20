using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DNACollider : MonoBehaviour
{
    [SerializeField]
    private string playerTag = "Player";
    [Range(0f, 20f)] public int numEggsToWin = 5;

    [HideInInspector] public static int eggsCollected = 0;

    [SerializeField] public GameObject door;
    [SerializeField] public Vector3 doorFinalPos;

    public bool hasCoroutineRun = false;

    //when something enters the egg’s trigger zone, check if it is the player character
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(playerTag))
        {
            //call the collect egg method on the chicken
            other.gameObject.GetComponent<DNACollect>().CollectEgg(gameObject);
        }
    }
    //method to call when game is won
    IEnumerator GameWon()
    {
        //get the door’s start position
        Vector3 doorStartPos = door.transform.position;
        float i = 0;

        //open the door
        while (door.transform.position.y > doorFinalPos.y)
        {
            door.transform.position = Vector3.Lerp(doorStartPos, doorFinalPos, i / 10);

            i += 0.1f;
            yield return null;
        }
    }
    //check if the winning conditions have been met

    private void Update()
    {
        if (eggsCollected >= numEggsToWin && !hasCoroutineRun)
        {
            hasCoroutineRun = true;
            StartCoroutine("GameWon");
        }
    }
}
