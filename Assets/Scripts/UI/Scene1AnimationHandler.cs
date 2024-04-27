using System;
using UnityEngine;

public class Scene1AnimationHandler : MonoBehaviour
{

    public event Action Handle;

    public void HandleEnd()
    {
        Handle?.Invoke();
    }
}
