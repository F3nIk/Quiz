using DG.Tweening;

using System.Collections;

using UnityEngine;

public class EaseInBounce : TweenBase
{
    [SerializeField] [Min(.1f)] private float _power = 1f;

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
            .DOLocalMoveY(transform.localPosition.y + _power, duration)
            .SetEase(Ease.InBounce)
            .SetLoops(2, LoopType.Yoyo)
            .onComplete += OnComplete;
    }

}
