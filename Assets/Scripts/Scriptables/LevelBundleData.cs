using System.Collections.Generic;

using UnityEngine;

[CreateAssetMenu(menuName = "Data Bundles/Level Bundle")]
public class LevelBundleData : ScriptableObject
{
    [SerializeField] private CellBundleData[] _cellBundleData;
    [SerializeField] private int _cellsPerLevel;

    private List<CellBundleData> _cellBundleDataRemaining;
    private CellData _targetCell;

    private void OnEnable() => Reset();

    public LevelData GetLevelData(int currentLevel)
    {
        List<CellData> data = new List<CellData>();

        for (int i = 0; i < currentLevel * _cellsPerLevel; i++)
        {
            data.Add(GetRandomCellData());
        }

        _targetCell = data[Random.Range(0, data.Count - 1)];

        return new LevelData(data, _targetCell);
    }

    private CellData GetRandomCellData()
    {
        CellBundleData randomBundleData = _cellBundleDataRemaining[Random.Range(0, _cellBundleDataRemaining.Count)];
        _cellBundleDataRemaining.Remove(randomBundleData);

        return randomBundleData.Data;
    }

    public void Reset()
    {
        _cellBundleDataRemaining = new List<CellBundleData>(_cellBundleData);
        _cellBundleDataRemaining.RemoveAll(cellBundle => cellBundle.Data == _targetCell);
        _targetCell = null;
    }
}
