using UnityEngine;

[CreateAssetMenu(menuName = "Data Bundles/Cell Bundle")]
public class CellBundleData : ScriptableObject
{
    [SerializeField] private CellData _data;
    public CellData Data => _data;
}
