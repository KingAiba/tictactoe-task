using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int rows=2;
    public int cols=2;

    public TicTacToeMatrix TTTMat;

    public int[,] mat;

    public float cellSize = 1;
    public float cellSpacing = 1;

    CellStatus curr;
    public int currPlayer = 0;
    public int NumOfPlayers = 2;

    public int TurnsTaken = 0;

    public CellStatus CurrentPlayer = CellStatus.Circle;

    public bool isWon = false;

    // public Cell[,] cellMat;
    public GameObject cellPrefabs;

    public delegate void OnWinDelegate();
    public OnWinDelegate OnWinEvent;

    public delegate void StatusUpdatedDelegate(int Row, int Col, CellStatus status);
    public StatusUpdatedDelegate StatusUpdated;

    public List<UnityCell> ActiveUnityCells; 

    void Start()
    {
        TTTMat = new TicTacToeMatrix(rows, cols);
        TTTMat.StatusChange += SetMatrixCellStatus;
        ActiveUnityCells = new List<UnityCell>();
        //InistializeGrid();
        //StatusUpdated += Statys
        mat = TTTMat.mat;
        DrawGrid();
    }

   
    void Update()
    {
        
    }

    public void CellUnityCreated(int x, int z)
    {
        GameObject newCell = Instantiate(cellPrefabs, new Vector3(x * cellSpacing, 0, z * cellSpacing), cellPrefabs.transform.rotation);
        newCell.transform.localScale = new Vector3(cellSize, cellSize, cellSize);

        UnityCell newCellScript = newCell.GetComponent<UnityCell>();
        ActiveUnityCells.Add(newCellScript);

        Cell curCell = TTTMat.GetCell(x, z);
        newCellScript.SetCell(curCell);
        newCellScript.SetRowAndCol(curCell.row, curCell.col);
        curCell.OnStatusChange += newCellScript.SetStatus;
        curCell.OnPositionChange += newCellScript.SetRowAndCol;

        //newCellScript.cellScript = TTTMat.GetCell(x, z);
        newCellScript.SetGameManager(this);

    }

    public void DrawGrid()
    {
        for(int x=0; x<rows; x++)
        {
            for(int z=0; z<cols; z++)
            {
                CellUnityCreated(x, z);
                //GameObject newCell = Instantiate(cellPrefabs, new Vector3(x * cellSpacing, 0, z * cellSpacing), cellPrefabs.transform.rotation);
                //newCell.transform.localScale = new Vector3(cellSize, cellSize, cellSize);

                //UnityCell newCellScript = newCell.GetComponent<UnityCell>();
                //newCellScript.cellScript.SetRowAndCol(x, z);

                //newCellScript.gameManager = this;
            }
        }
    }

    public CellStatus GetNextPlayer()
    {
        int temp = currPlayer % NumOfPlayers;
        currPlayer = temp + 1;
        return (CellStatus)(temp);
    }

    public void SetStatusOnClick(int Row, int Col)
    {
        curr = GetNextPlayer();
        TTTMat.SetCellStatus(Row, Col, curr);
    }

    public void SetMatrixCellStatus(int Row, int Col, CellStatus status)
    {
        TurnsTaken += 1;
        //TTTMat.SetCellStatus(Row, Col, status);
        isWon = TTTMat.CheckWin(Row, Col);
        if (isWon)
        {
            OnWinEvent?.Invoke();
            //TTTMat.SetRowValuesTo(Row, (int)CellStatus.Win);
            //TTTMat.SetColValuesTo(Col, (int)CellStatus.Win);
            Debug.Log("Won");
        }
        else if(TurnsTaken >= rows*cols)
        {
            Debug.Log("Draw");
        }
        
        Debug.Log(TTTMat.PrintMat());
    }
}
