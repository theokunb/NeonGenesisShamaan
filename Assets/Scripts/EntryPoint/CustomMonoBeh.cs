using UnityEngine;

public class CustomMonoBeh : MonoBehaviour
{
    [SerializeField] private int _priority;

    public int Priority => _priority;

    public virtual void Awake()
    {
    }

    public virtual void OnEnable()
    {
    }

    public virtual void OnDisable()
    {
    }

    public virtual void Start()
    {
    }

    public virtual void Update()
    {
    }
}
