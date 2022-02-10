using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CellStatus
{   
    Circle,
    Cross,
    Win,
    None,
}

public class Cell
{
    public int row;
    public int col;

    public CellStatus status;
    
    public delegate void OnStatusChangeDelegate(CellStatus Status);
    public OnStatusChangeDelegate OnStatusChange;


    public delegate void OnPositionChangeDelegate(int row, int col);
    public OnPositionChangeDelegate OnPositionChange;

    public Cell(int Row, int Col, CellStatus Status = CellStatus.None)
    {
        row = Row;
        col = Col;
        status = Status;
    }

    public int GetRow()
    {
        return row;
    }

    public void SetRow(int Row)
    {
        row = Row;
    }

    public int GetCol()
    {
        return col;
    }

    public void SetCol(int Col)
    {
        col = Col;
    }

    public void SetRowAndCol(int Row, int Col)
    {
        SetRow(Row);
        SetCol(Col);
        OnPositionChange?.Invoke(Row, Col);
    }

    public CellStatus GetStatus()
    {
        return status;
    }

    public void SetStatus(CellStatus Status)
    {
        status = Status;
        OnStatusChange?.Invoke(Status);
    }

    
}

