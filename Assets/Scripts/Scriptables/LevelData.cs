using System.Collections.Generic;
using System.Linq;

public class LevelData
{
    private List<CellData> _cellsData;
    private readonly CellData _targetCell;

    private LevelData() { }

    public LevelData(List<CellData> data, CellData target)
    {
        _cellsData = new List<CellData>();
        _cellsData = data;
        _targetCell = target;
    }

    public CellData Target => _targetCell;

    public CellData GetCellData()
    {
        CellData cell = _cellsData.First();
        _cellsData.Remove(cell);
        return cell;
    }
}