using UnityEngine;
using UnityEngine.Events;

public class LifeCycle : MonoBehaviour
{
    [SerializeField] private CellGrid _grid;
    [SerializeField] private Task _task;
    [SerializeField] private LevelBundleData _levelConstructor;
    [SerializeField] private int _gridRowsPerLevel;
    [SerializeField] private int _iterations = 3;

    public UnityEvent sessionEnded = new UnityEvent();

    private LevelData _data;
    private int _currentLevel = 0;

    private void Start()
    {
        Reset();
        LoadNextLevel();
    }

    public void SetLevelConstructor(LevelBundleData constructor)
    {
        _levelConstructor = constructor;
        _levelConstructor.Reset();
    }

    public void LoadNextLevel()
    {
        _data = _levelConstructor.GetLevelData(_currentLevel);

        foreach (Cell cell in _grid.Cells) cell.SetCellData(_data.GetCellData());

        _task.Set(_data.Target);
    }

    private void OnCellClicked(Cell cell)
    {

        if (cell.Idetinfier == _data.Target.Identifier)
        {
            CorrectClicked();
            cell.OnCorrectClick();
        }
        else
        {
            cell.OnUncorrectClick();
        }
    }

    private void CorrectClicked()
    {
        _currentLevel++;

        if (_currentLevel - 1 >= _iterations) sessionEnded?.Invoke();
        else SetNextIteration();
    }

    private void SetNextIteration()
    {
        _grid.Upgrade(_gridRowsPerLevel);
        _levelConstructor.Reset();
        LoadNextLevel();
    }

    public void Reset()
    {
        _currentLevel = 1;
        _levelConstructor.Reset();
        _data = null;
        _task.Reset();
        _grid.cellClicked.RemoveListener(OnCellClicked);
        _grid.ClearGrid();
        _grid.Upgrade(_gridRowsPerLevel * _currentLevel);
        _grid.cellClicked.AddListener(OnCellClicked);
    }
}
