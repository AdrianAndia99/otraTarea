using UnityEngine;
using UnityEngine.AI;

public class enemi : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    public Transform playerTransform;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.isStopped = true;
    }

    private void Update()
    {
        if (playerTransform != null)
        {
            navMeshAgent.SetDestination(playerTransform.position);
        }
    }
    public void StartMovement()
    {
        navMeshAgent.isStopped = false;
    }
}