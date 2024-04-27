using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    public bool HasDestroyed { get; protected set; }

    public virtual void SetTarget(Player player) { }
}
