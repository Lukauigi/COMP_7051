using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalDetection : MonoBehaviour
{
    public static readonly float WAIT_DURATION = 2f;

    private Coroutine goalTrigger;

    // Ref(s) to other GameObjects
    private GameObject player;
    private GameObject mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    private void OnTriggerEnter(Collider other)
    {
        print("Trigger Enter");
        
        if (other.gameObject.tag == "Player")
        {
            print("Trigger by player tag");
            goalTrigger = StartCoroutine(GoalCountdown());
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        print("Trigger Exit");
        if (other.gameObject.tag == "Player")
        {
            StopCoroutine(goalTrigger);
        }
    }

    private IEnumerator GoalCountdown()
    {
        yield return new WaitForSeconds(WAIT_DURATION);
        GoalReached();
    }

    private void GoalReached()
    {
        Destroy(player);
        Destroy(mainCamera);
    }
}
