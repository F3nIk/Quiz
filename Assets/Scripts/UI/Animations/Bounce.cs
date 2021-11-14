using DG.Tweening;

using System.Collections;

using UnityEngine;

public class Bounce : TweenBase
{
    [SerializeField] private Vector3 _power = new Vector3(1, 1, 1);
    [SerializeField] [Min(1)] private int _times = 1;


    private void Awake()
    {
        if (_invokeOnAwake == true) Invoke();
    }

    public override void InvokeImmediatly() => DelayedInvoke(0, .1f);

    protected override IEnumerator DelayedInvoke(float delay, float duration)
    {
        _invoking = true;

        yield return new WaitForSeconds(delay);

        transform
            .DOScale(_power, duration)
            .SetLoops(2 * _times, LoopType.Yoyo)
            .onComplete += OnComplete;
    }

}
