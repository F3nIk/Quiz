using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(GridLayoutGroup))]
public class CellGrid : MonoBehaviour
{
    [SerializeField] private Cell _cellPrefab;

    private GridLayoutGroup _grid;
    private List<Cell> _cells;

    public CellEvent cellClicked = new CellEvent();

    public IEnumerable<Cell> Cells => _cells;


    private void Awake() => Init();

    public void Upgrade(int additionRows)
    {
        //_cells.ForEach(cell => cell.Clear());

        for (int i = 0; i < _grid.constraintCount * additionRows; i++)
        {
            Cell cell = CreateCell();
            cell.clicked.AddListener(OnCellClicked);
            _cells.Add(cell);
        }
    }

    public void ClearGrid()
    {
        foreach (Cell cell in _cells)
        {
            cell.clicked.RemoveAllListeners();
            Destroy(cell.gameObject);
        }
        _cells = new List<Cell>();
    }

    private Cell CreateCell() => Instantiate(_cellPrefab, transform);

    private void OnCellClicked(Cell cell) => cellClicked?.Invoke(cell);
    
    private void Init()
    {
        _grid = GetComponent<GridLayoutGroup>();
        _grid.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        _cells = new List<Cell>();
    }

}
