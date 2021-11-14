using UnityEngine;

public class Session : MonoBehaviour
{
    [SerializeField] private LifeCycle _lifeCycle;
    [SerializeField] private SceneReloadScreen _reloadScreen;

    private void OnEnable()
    {
        _reloadScreen.showed.AddListener(OnLoadingScreenShowed);
    }

    private void OnDisable()
    {
        _reloadScreen.showed.RemoveListener(OnLoadingScreenShowed);
    }

    public void ReloadSession() => _reloadScreen.Show();

    private void Reload()
    {
        _lifeCycle.Reset();
        _lifeCycle.LoadNextLevel();
    }
    private void OnLoadingScreenShowed()
    {
        Reload();
        _reloadScreen.Hide();
    }

    private void OnReloadComplete(AsyncOperation ao) => ao.completed -= OnReloadComplete;
}
