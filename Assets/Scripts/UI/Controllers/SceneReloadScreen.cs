using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Canvas))]
public class SceneReloadScreen : MonoBehaviour
{
    [SerializeField] private FadeableDynamicScreen _screen;

    [HideInInspector] public UnityEvent showed = new UnityEvent();
    [HideInInspector] public UnityEvent hidden = new UnityEvent();

    private Canvas _canvas;

    private void Awake()
    {
        _canvas = GetComponent<Canvas>();
        _canvas.enabled = false;
    }

    private void OnEnable()
    {
        _screen.showed.AddListener(OnScreenShowComplete);
        _screen.hidden.AddListener(OnScreenHiddenComplete);
    }

    private void OnDisable()
    {
        _screen.showed.RemoveListener(OnScreenShowComplete);
        _screen.hidden.RemoveListener(OnScreenHiddenComplete);
    }

    public void Show()
    {
        _canvas.enabled = true;
        _screen.Show();
    }

    public void Hide() => _screen.Hide();

    private void OnScreenShowComplete() => showed?.Invoke();

    private void OnScreenHiddenComplete()
    {
        _canvas.enabled = false;
        hidden?.Invoke();
    }
}
