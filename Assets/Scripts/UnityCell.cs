using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityCell : MonoBehaviour
{
    public int row;
    public int col;

    public bool onMouseDownEnabled = true;

    public CellStatus curr;

    public CellStatus cellStatus;
    public Cell cellScript;

    public GameManager gameManager;

    public List<GameObject> childObjects;
    public Cell.OnStatusChangeDelegate onStatusChange;

    private void Awake()
    {
        //cellScript = new Cell(row, col);

        //onStatusChange = cellScript.OnStatusChange;
     
    }

    void Start()
    {
        GetAllChildren();
        cellStatus = CellStatus.None;
        CellStatusUpdate();

        //cellScript.OnStatusChange += SetStatus;
        //cellScript.OnPositionChange += SetRowAndCol;
        
    }

    void Update()
    {
        
    }

    public void SetGameManager(GameManager gm)
    {
        gameManager = gm;
        gameManager.OnWinEvent += ToggleOnMouseDown;
    }

    public void SetRow(int Row)
    {
        row = Row;
    }

    public int GetRow()
    {
        return row;
    }

    public void SetCol(int Col)
    {
        col = Col;
    }

    public int GetCol()
    {
        return col;
    }

    public void SetRowAndCol(int Row, int Col)
    {
        SetRow(Row);
        SetCol(Col);
    }

    private void GetAllChildren()
    {
        foreach (Transform child in transform)
        {
            childObjects.Add(child.gameObject);
        }
    }

    public CellStatus GetStatus()
    {
        return cellStatus;
    }

    public void SetStatus(CellStatus Status)
    {
        cellStatus = Status;
        //cellScript.OnStatusChange(Status);
        //onStatusChange(Status);
        CellStatusUpdate();
    }


    public void OnCellUpdate()
    {
        // TODO : Fill
        // cellScript
    }

    public void CellStatusUpdate()
    {
        for(int i = 0; i < childObjects.Count; i++)
        {
            if(i == (int)cellStatus)
            {
                childObjects[i].SetActive(true);
            }
            else
            {
                childObjects[i].SetActive(false);
            }
        }
    }

    public void ToggleOnMouseDown()
    {
        onMouseDownEnabled = !onMouseDownEnabled;
    }

    private void OnMouseDown()
    {
        if(onMouseDownEnabled)
        {
            //SetStatus((CellStatus)(curr++ % childObjects.Count));
            //cellScript.SetStatus((CellStatus)(curr++ % childObjects.Count));

            //curr = gameManager.GetNextPlayer();
            //cellScript.SetStatus(curr);
            gameManager.SetStatusOnClick(row, col);
            if(!gameManager.isWon)
            {
                ToggleOnMouseDown();
                gameManager.OnWinEvent -= ToggleOnMouseDown;
            }

        }

    }

    private void OnDestroy()
    {
        
        cellScript.OnStatusChange -= SetStatus;
        cellScript.OnPositionChange -= SetRowAndCol;
        gameManager.OnWinEvent -= ToggleOnMouseDown;
    }

    public void SetCell(Cell cell)
    {
        cellScript = cell;
        // update status delegate suscribe
        // update curr status
    }

}
