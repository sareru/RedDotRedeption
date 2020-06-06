using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public SphereCollider goal1;
    public SphereCollider goal2;

    public NavMeshAgent agent;

    SphereCollider[] goals;

    int turns = 0;

    // Start is called before the first frame update
    void Start()
    {
        goals = new SphereCollider[] { goal1, goal2 };

        agent.SetDestination(goals[turns].gameObject.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider == goals[turns % 2])
        {
            turns++;
            agent.SetDestination(goals[turns % 2].gameObject.transform.position);
        }
    }
}
