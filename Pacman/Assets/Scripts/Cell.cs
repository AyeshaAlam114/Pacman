using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell 
{
    int rowIndex, colIndex;
    public enum Status { outerarea,ownedArea};
    public Status currentStatus;

    public delegate void StatusUpdate(Status currentStatus);
    public StatusUpdate statusUpdate;

    public delegate void CellStatusUpdate(int row,int col);
    public CellStatusUpdate cellStatusUpdate;

    Vector3 cellposition;
    CellView cellView;

    public Cell(int row,int col)
    {
           rowIndex = row;
        colIndex = col;
    }

    public CellView GetCellView()
    {
        return this.cellView;
    }
    public void SetCellView(CellView cellView)
    {
        this.cellView = cellView;
    }
    public void SetStatus(Status CurrentStatus)
    {
        //Debug.Log("1");
        currentStatus = CurrentStatus;
        statusUpdate?. Invoke(currentStatus);
       
    }
    public void SetStatus(int CurrentStatus)
    {
       // Debug.Log("1");
        currentStatus = (Status)CurrentStatus;
        statusUpdate?.Invoke(currentStatus);

    }
    public Status GetStatus()
    {
       return  currentStatus;
    }
    public Vector2 GetCellIndex()
    {
        return new Vector2(rowIndex,colIndex);
    }
    public Vector3 GetCellPosition()
    {
        return cellposition;
    }
    public void SetCellPosition(Vector3 cellposition)
    {
        this.cellposition = cellposition;
    }
    public void CellInteraction()
    {

        cellStatusUpdate?.Invoke(rowIndex,colIndex);

    }
}
