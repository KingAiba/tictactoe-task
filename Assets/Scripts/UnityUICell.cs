using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UnityUICell : MonoBehaviour, IPointerDownHandler
{

    public int row;
    public int col;

    public bool onPointerDownEnabled = true;

    public CellStatus curr;

    public CellStatus cellStatus;
    public Cell cellScript;

    public GameManager gameManager;

    public List<GameObject> childObjects;
    public Cell.OnStatusChangeDelegate onStatusChange;

    void Start()
    {
        GetAllChildren();
        cellStatus = CellStatus.None;
        CellStatusUpdate();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (onPointerDownEnabled)
        {
            gameManager.SetStatusOnClick(row, col);
            if (!gameManager.isWon)
            {
                //ToggleOnMouseDown();
                //gameManager.OnWinEvent -= ToggleOnMouseDown;
            }

        }
    }

    public void SetGameManager(GameManager gm)
    {
        gameManager = gm;
        //gameManager.OnWinEvent += ToggleOnMouseDown;
    }

    public void CellStatusUpdate()
    {
        for (int i = 0; i < childObjects.Count; i++)
        {
            if (i == (int)cellStatus)
            {
                childObjects[i].SetActive(true);
            }
            else
            {
                childObjects[i].SetActive(false);
            }
        }
    }

    private void GetAllChildren()
    {
        foreach (Transform child in transform)
        {
            childObjects.Add(child.gameObject);
        }
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

    public void SetStatus(CellStatus Status)
    {
        cellStatus = Status;
        //cellScript.OnStatusChange(Status);
        //onStatusChange(Status);
        CellStatusUpdate();
    }

    public void SetCell(Cell cell)
    {
        cellScript = cell;
        // update status delegate suscribe
        // update curr status
    }

    public CellStatus GetStatus()
    {
        return cellStatus;
    }

    public void ToggleOnMouseDown()
    {
        onPointerDownEnabled = !onPointerDownEnabled;
    }
}
