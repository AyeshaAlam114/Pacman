using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class GridView : MonoBehaviour
{
    public int numberOfRows, numberOfCol;
    public GameObject cellPrefab;
    public Transform SpawnPosition;

    public float horizontalGap, verticalGap, nextLineIndicator=0;
    public GameObject canvas;


    

    // Start is called before the first frame update
    void Start()
    {
        Initializer();
        
    }

    public void Initializer()
    {
        Grid grid = new Grid(numberOfRows, numberOfCol);
        grid.cellCreated += CellCreator;
        grid.GridInitializer();

        GridMovement.cellss = grid.cellsGrid;
     
    }

    Vector3 PositionSetter()
    {
        if (nextLineIndicator < numberOfCol)
        {

            nextLineIndicator++;
            return SpawnPosition.position = HorizontalShift();
        }
        else
        {

            SpawnPosition.position = VerticalShift();
            nextLineIndicator = 0;
            nextLineIndicator++;
            return SpawnPosition.position;
        }
        

    }

    private Vector3 VerticalShift()
    {
        
        float incrementX = 104f;
        float incrementY = SpawnPosition.position.y - 100f;
        return new Vector3(incrementX, incrementY, SpawnPosition.position.z);
    }

    private Vector3 HorizontalShift()
    {
        float increment = SpawnPosition.position.x + 100f;
        return new Vector3(increment, SpawnPosition.position.y, SpawnPosition.position.z);
    }

    public void CellCreator(Cell cell)
    {
        Debug.Log("ss");
        CellView cellView = Instantiate(cellPrefab, PositionSetter(), Quaternion.identity, canvas.transform).GetComponent<CellView>();
        cellView.SetCell(cell);
        cell.SetCellPosition(cellView.gameObject.transform.position);
        cell.SetCellView(cellView);

    }
}
