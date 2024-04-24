using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class AIController : MonoBehaviour
{
    [SerializeField]
    NavMeshAgent agent;

    [SerializeField]
    Transform target;

    [SerializeField]
    WaypointsPathController waypointsPathController;

    bool isChasing;

    Coroutine activeCorout;

    Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
        EnemyAI();
    }

    public void EnemyAI()
    {
        StartCoroutine(PatrolCorout());
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (activeCorout != null) return;
           activeCorout = StartCoroutine(ChaseCorout(collision.gameObject));
        }
    }

    IEnumerator ChaseCorout(GameObject player)
    {
        while (true)
        {
            if (Vector3.Distance(transform.position, startPos) > 25)
                break;
            agent.SetDestination(player.transform.position);
            yield return null;
        }
        activeCorout = StartCoroutine(PatrolCorout());
    }


    IEnumerator PatrolCorout()
    {
        int currentWaypointIndex = 0;
        WaypointsPathController.WaypointInfo waypointInfo;
        while (true)
        {
            waypointInfo = waypointsPathController.GetNextWaypoint(currentWaypointIndex);
            currentWaypointIndex = waypointInfo.index;
            agent.SetDestination(waypointInfo.target.position);
            while (agent.pathPending)
                yield return null;

            if (agent.pathStatus == NavMeshPathStatus.PathComplete)
            {
                while (agent.remainingDistance > 1.6f)
                {
                    yield return null;
                }
            }
            yield return null;
        }
    }

}
