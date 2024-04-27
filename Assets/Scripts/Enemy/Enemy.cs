using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.updateRotation = false;
        _navMeshAgent.updateUpAxis = false;
    }

    private void OnEnable()
    {
        _navMeshAgent.enabled = true;
    }

    private void OnDisable()
    {
        _navMeshAgent.enabled = false;
    }

    private void Update()
    {
        _navMeshAgent.SetDestination(Vector3.zero);
    }
}
