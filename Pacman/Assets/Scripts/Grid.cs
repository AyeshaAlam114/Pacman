using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : Matrix
{
    public List<List<Cell>> cellsGrid = new List<List<Cell>>();

    public delegate void CellIsCreated(Cell cell);
    public CellIsCreated cellCreated;
    int numberOfRows;
    int numberOfColumns;
    bool winCheck;

    // Cell.Status currentTurn = Cell.Status.cross;

    public Grid(int NumberOfRows, int NumberOfColumns) : base(NumberOfRows, NumberOfColumns)
    {
        //GridInitializer(numberOfRows, numberOfColumns);
        numberOfRows = NumberOfRows;
        numberOfColumns = NumberOfColumns;
        //  winCheck = false;
    }

    public void GridInitializer()
    {
        for (int row = 0; row < numberOfRows; row++)
        {
            cellsGrid.Add(new List<Cell>());
            for (int col = 0; col < numberOfColumns; col++)
            {
                Cell tempCell = new Cell(row, col);
                cellsGrid[row].Add(tempCell);
                cellCreated?.Invoke(cellsGrid[row][col]);
                cellsGrid[row][col].cellStatusUpdate += GridCellStatus;
            }
        }
        InitialGridSetting();

    }
    public void InitialGridSetting()
    {
        SetColumnOfMatrixTo(0, 1);
        SetColumnOfMatrixTo(cellsGrid[0].Count - 1, 1);
        SetRowOfMatrixTo(0, 1);
        SetRowOfMatrixTo(cellsGrid.Count - 1, 1);
        UpdateGridDisplay();
    }

    //public void aa(int row, int col)
    //{
    //    cellsGrid[row][col].cellStatusUpdate += GridCellStatus;
    //}


    static int M = 10;
    static int N = 10;

    //public void SetValues()
    //{
    //    matrixHolder.Count;
    //}

    // A recursive function to replace
    // previous color 'prevC' at '(x, y)'
    // and all surrounding pixels of (x, y)
    // with new color 'newC' and
    static void floodFillUtil(List<List<int>> screen,
                              int x, int y,
                              int prevC, int newC)
    {
        // Base cases
        if (x < 0 || x >= M ||
            y < 0 || y >= N)
            return;
        if (screen[x][y] != prevC)
            return;

        // Replace the color at (x, y)
        screen[x][y] = newC;

        // Recur for north, east, south and west
        floodFillUtil(screen, x + 1, y, prevC, newC);
        floodFillUtil(screen, x - 1, y, prevC, newC);
        floodFillUtil(screen, x, y + 1, prevC, newC);
        floodFillUtil(screen, x, y - 1, prevC, newC);
    }

    // It mainly finds the previous color
    // on (x, y) and calls floodFillUtil()
    static void floodFill(List<List<int>> screen, int x,
                          int y, int newC)
    {
        int prevC = screen[x][y];
        if (prevC == newC)
            return;
        floodFillUtil(screen, x, y, prevC, newC);
    }


    public void GridCellStatus(int row, int col)
    {
        
        if (cellsGrid[row][col].GetStatus() == Cell.Status.outerarea)
        {
            SetSingleElementAtIndex(row, col, (int)Cell.Status.ownedArea);
            UpdateGridDisplay();
        }
        if (col > 0 && col < matrixHolder[0].Count)
        {
            if (matrixHolder[row + 1][col] == 1 && matrixHolder[row - 1][col] == 1)
            {
                //on vertical partition fill right side with colour
                int x = row, y = col + 1, newC = 1;
                floodFill(matrixHolder, x, y, newC);
                UpdateGridDisplay();
            }
        }
        
        if (row > 0 && row< matrixHolder.Count)
        {
            if (matrixHolder[row][col + 1] == 1 && matrixHolder[row][col - 1] == 1)
            {
                //on horizontal partition fill upper side with colour
                int x = row - 1, y = col, newC = 1;
                floodFill(matrixHolder, x, y, newC);
                UpdateGridDisplay();
            }
        }

    }

    void UpdateGridDisplay()
    {

        for (int row = 0; row < cellsGrid.Count; row++)
        {
            for (int col = 0; col < cellsGrid[row].Count; col++)
            {
                cellsGrid[row][col].SetStatus(matrixHolder[row][col]);
            }
        }

        //PrintMatrix();
    }

}
