using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Canvas))]
public class EndGameUIContoroller : MonoBehaviour
{
    [SerializeField] private Button _restartButton;
    [SerializeField] private FadeableDynamicScreen _background;

    [SerializeField] private UnityEvent restart;

    private Canvas _canvas;

    private void Awake() => _canvas = GetComponent<Canvas>();

    private void OnEnable() => _restartButton.onClick.AddListener(OnRestartButtonClicked);

    private void OnDisable() => _restartButton.onClick.RemoveListener(OnRestartButtonClicked);

    public void Activate()
    {
        _canvas.enabled = true;
        _background.Show();
    }

    private void OnRestartButtonClicked() => restart?.Invoke();
}
