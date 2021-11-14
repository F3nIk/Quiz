using System.Collections;

using UnityEngine;
using UnityEngine.Events;

public abstract class TweenBase : MonoBehaviour
{
    [SerializeField] [Range(.1f, 30f)] protected float _duration = .25f;
    [SerializeField] [Min(0)] protected float _invokeDelay = 0;
    [SerializeField] protected bool _invokeOnAwake = false;

    public UnityEvent complete = new UnityEvent();

    protected bool _invoking;

    public void Invoke()
    {
        if (_invoking == false) StartCoroutine(DelayedInvoke(_invokeDelay, _duration));
    }

    public abstract void InvokeImmediatly();

    protected abstract IEnumerator DelayedInvoke(float delay, float duration);
    protected void OnComplete()
    {
        complete?.Invoke();
        _invoking = false;
    }
}
