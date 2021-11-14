using DG.Tweening;

using System.Collections;

using UnityEngine;
using UnityEngine.UI;

public class FadeIn : TweenBase
{
    [SerializeField] [Range(.1f, 1f)] private float _targetAlpha = 1;

    private Graphic _target;

    private void Awake()
    {
        _target = GetComponent<Graphic>();

        if (_invokeOnAwake == true) Invoke();
    }

    public override void InvokeImmediatly()
    {
        _target.color = _target.color * new Color(1, 1, 1, _targetAlpha);
        OnComplete();
    }
    protected override IEnumerator DelayedInvoke(float delay, float duration)
    {
        _invoking = true;

        _target.color = _target.color * new Color(1, 1, 1, 0);

        yield return new WaitForSeconds(delay);

        _target.DOFade(_targetAlpha, duration).onComplete += OnComplete;
    }

}
