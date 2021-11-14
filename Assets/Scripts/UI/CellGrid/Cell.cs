using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;



[RequireComponent(typeof(Image))]
public class Cell : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private float _cellItemScaleAmount = 0.75f;
    [SerializeField] private CellItemView _itemView;

    [HideInInspector] public CellEvent clicked = new CellEvent();
    public UnityEvent correctClick = new UnityEvent();
    public UnityEvent uncorrectClick = new UnityEvent();

    private CellData _cellData;
    private Image _background;
    private RectTransform _rectTransform;

    public string Idetinfier => _cellData.Identifier;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _background = GetComponent<Image>();
        SetRandomBackgroundColor();
    }

    public void SetCellData(CellData data)
    {
        _cellData = data;
        _itemView.Clear();
        _itemView.SetSprite(data.Sprite);
        _itemView.SetRotation(data.SpriteRotation);
        _itemView.SetScale(_cellItemScaleAmount);
    }

    public void Clear()
    {
        _cellData = null;
        _itemView.Clear();
    }

    public void OnCorrectClick() => correctClick?.Invoke();

    public void OnUncorrectClick() => uncorrectClick?.Invoke();

    public void OnPointerClick(PointerEventData eventData) => clicked?.Invoke(this);

    private void SetRandomBackgroundColor()
    {
        Color color = new Color(Random.Range(.5f, 1f), Random.Range(.5f, 1f), Random.Range(.5f, 1f));
        _background.color = color;
    }

}
