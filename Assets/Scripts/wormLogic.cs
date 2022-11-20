using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;
public static class Extensions
{
    private static System.Random rand = new System.Random();

    public static void Shuffle<T>(this IList<T> values)
    {
        for (int i = values.Count - 1; i > 0; i--)
        {
            int k = rand.Next(i + 1);
            T value = values[k];
            values[k] = values[i];
            values[i] = value;
        }
    }
}
public class wormLogic : MonoBehaviour
{
    public List<Transform> navigationPoints;
    public Transform goal;
    NavMeshAgent agent;
    [SerializeField] RoundController roundController;
    public bool startedGame = false;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (startedGame)
            if (!agent.pathPending)
            {
                if (agent.remainingDistance <= agent.stoppingDistance)
                {
                    if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                    {
                        // Done
                        navigationPoints.Shuffle();
                        agent.destination = navigationPoints[0].position;
                    }
                }
            }
            else
                ;
        else
            transform.position = goal.position;


    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.tag == "Player")
        {
            roundController.GameLostByWorm();
        }
    }

}
