using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : BaseEnemy
{
    private NavMeshAgent _navMeshAgent;
    private Player _target;

    protected Player Target => _target;

    
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

    protected virtual void Update()
    {
        if(_target != null)
        {
            _navMeshAgent.SetDestination(_target.transform.position);
        }
    }

    private void OnDestroy()
    {
        HasDestroyed = true;
    }

    public virtual void Attack()
    {
        
    }

    public override void SetTarget(Player player)
    {
        _target = player;
    }
}
