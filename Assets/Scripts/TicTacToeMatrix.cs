using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicTacToeMatrix : Matrix
{

    public Cell[,] cellMatrix;

    public delegate void StatusChangeDelegate(int Row, int Col, CellStatus Status);
    public StatusChangeDelegate StatusChange;

    public delegate void OnCellCreatedDelegate();
    public OnCellCreatedDelegate OnCellCreate;


    public TicTacToeMatrix(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        //SetMatValuesTo((int)CellStatus.None);
        InistializeGrid();
    }

    public TicTacToeMatrix(int [,] arr) : base(arr)
    {
        //SetMatValuesTo((int)CellStatus.None);
        InistializeGrid();
    }

    public void InitializeCell()
    {

    }

    public Cell GetCell(int Row, int Col)
    {
        return cellMatrix[Row, Col];
    }

    public void SetCellStatus(int Row, int Col, CellStatus Status)
    {
        InsetValue(Row, Col, (int)Status+1);
        cellMatrix[Row, Col].SetStatus(Status);
        StatusChange?.Invoke(Row, Col, Status);
    }

    public void SetStatusOfAll(CellStatus status)
    {
        SetMatValuesTo((int)status+1);
    }

    public bool CheckWin(int row, int col)
    {
        if(IsRowSame(row))
        {
            SetWinOnRowWin(row);
            SyncMats();
            return true;
        }
        if(IsColSame(col))
        {
            SetWinOnColWin(col);
            SyncMats();
            return true;
        }
        if(IsDiagonalSame() && row == col)
        {
            SetWinOnDiagonalWin();
            SyncMats();
            return true;
        }
        if(IsInverseDiagonalSame() && row == cols - col - 1)
        {
            SetWinOnInverseWin();
            SyncMats();
            return true;
        }

        return false;
    }

    public void SetWinOnRowWin(int Row)
    {

        SetRowValuesTo(Row, (int)CellStatus.Win+1);
        
    }

    public void SetWinOnColWin(int Col)
    {
        SetColValuesTo(Col, (int)CellStatus.Win + 1);
    }

    public void SetWinOnDiagonalWin()
    {
        SetDiagonal((int)CellStatus.Win + 1);
        //SetDiagonalValuesTo(Col, (int)CellStatus.Win + 1);
    }

    public void SetWinOnInverseWin()
    {
        SetInverseDiagonal((int)CellStatus.Win + 1);
    }

    public Cell MakeCell(int Row, int Col)
    {
        return new Cell(Row, Col);
    }

    public void SyncMats()
    {
        //base.OnMatrixUpdate();
        // Sync all matrix value with non monocell
        for(int i=0;i<rows;i++)
        {
            for(int j=0;j<cols;j++)
            {
                cellMatrix[i, j].SetStatus((CellStatus)mat[i, j]-1);
            }
        }
    }

    public void InistializeGrid()
    {
        cellMatrix = new Cell[rows, cols];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                cellMatrix[i, j] = new Cell(i, j);
            }
        }
    }

}
