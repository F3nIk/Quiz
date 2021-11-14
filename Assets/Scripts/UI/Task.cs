using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class Task : MonoBehaviour
{
    [SerializeField] private string _taskPrefix;
    private Text _text;
    private CellData _data;

    private void Awake() => Init();

    public void Set(CellData data)
    {
        _data = data;
        _text.text = _taskPrefix + data.Identifier;
    }

    public void Reset() => _data = null;

    private void Init() => _text = GetComponent<Text>();
}
