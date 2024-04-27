using UnityEngine;

public class BaseMonoBeh : MonoBehaviour
{
    [SerializeField] private int _priority;

    public int Priority => _priority;

    public virtual void BaseAwake()
    {
    }

    public virtual void BaseOnEnable()
    {
    }

    public virtual void BaseOnDisable()
    {
    }

    public virtual void BaseStart()
    {
    }
}
