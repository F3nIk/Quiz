using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class CellItemView : MonoBehaviour
{
    private RectTransform _rectTransform;
    private Image _image;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _image = GetComponent<Image>();
    }

    public void SetSprite(Sprite sprite)
    {
        _image.sprite = sprite;
        _image.SetNativeSize();
    }

    public void SetRotation(float zAngle) => transform.Rotate(Vector3.forward, zAngle);

    public void SetScale(float scale) => _rectTransform.sizeDelta *= scale;

    public void Clear()
    {
        _image.sprite = null;
        _rectTransform.SetPositionAndRotation(_rectTransform.position, new Quaternion(0, 0, 0, 0));
    }
}
