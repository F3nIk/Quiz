using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(FadeIn), typeof(FadeOut))]
public class FadeableDynamicScreen : MonoBehaviour
{
    private FadeIn _fadeIn;
    private FadeOut _fadeOut;

    public UnityEvent showed = new UnityEvent();
    public UnityEvent hidden = new UnityEvent();

    private bool _ready = true;

    private void Awake()
    {
        _fadeIn = GetComponent<FadeIn>();
        _fadeOut = GetComponent<FadeOut>();
    }

    private void OnEnable()
    {
        _fadeIn.complete.AddListener(OnFadeInComplete);
        _fadeOut.complete.AddListener(OnFadeOutComplete);
    }

    private void OnDisable()
    {
        _fadeIn.complete.RemoveListener(OnFadeInComplete);
        _fadeOut.complete.RemoveListener(OnFadeOutComplete);
    }

    public void Show()
    {
        if (_ready == false) return;

        _ready = false;
        _fadeIn.Invoke();
    }

    public void Hide()
    {
        if (_ready == false) return;

        _ready = false;
        _fadeOut.Invoke();
    }

    private void OnFadeInComplete()
    {
        _ready = true;
        showed?.Invoke();
    }

    private void OnFadeOutComplete()
    {
        _ready = true;
        hidden?.Invoke();
    }
}
