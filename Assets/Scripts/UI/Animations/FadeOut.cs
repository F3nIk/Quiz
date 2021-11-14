using DG.Tweening;

using System.Collections;

using UnityEngine;
using UnityEngine.UI;

public class FadeOut : TweenBase
{
    [SerializeField] [Range(0f, .9f)] private float _targetAlpha = 0;

    private Graphic _target;

    private void Awake()
    {
        _target = GetComponent<Graphic>();

        if (_invokeOnAwake) Invoke();
    }

    public override void InvokeImmediatly()
    {
        _target.color = _target.color * new Color(1, 1, 1, _targetAlpha);
        OnComplete();
    }

    protected override IEnumerator DelayedInvoke(float delay, float duration)
    {
        _invoking = true;

        yield return new WaitForSeconds(delay);

        _target.DOFade(_targetAlpha, duration).onComplete += OnComplete;
    }

}
