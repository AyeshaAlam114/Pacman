using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Matrix 
{
      protected List<List<int>> matrixHolder=new List<List<int>>();


   
    public  Matrix(int numberOfRows,int numberOfColumns)
    {
        for(int rows = 0; rows < numberOfRows; rows++)
        {
            matrixHolder.Add(new List<int>());
            for (int col = 0; col < numberOfColumns; col++)
            {
                matrixHolder[rows].Add(0);
            }
        }
    }

    public void SetMatrixOf(int ValueToSet)
    {
        for (int rows = 0; rows < matrixHolder.Count; rows++)
        {
            for (int col = 0; col < matrixHolder[0].Count; col++)
            {
                SetSingleElementAtIndex(rows, col, ValueToSet);
            }
        }
    }


    public void SetMatrix(int numberOfRows, int numberOfColumns,int[] valuesArray)
    {
        if (!(MxNValidation(numberOfRows, numberOfColumns, valuesArray)))
        {
            Debug.Log("given mxn are not matched with matrix's mxn");
            return;
        }
        int arrayIndexCounter = 0;
        for (int rows = 0; rows < matrixHolder.Count; rows++)
        {

            for (int col = 0; col < matrixHolder[rows].Count; col++)
            {
                SetSingleElementAtIndex(rows, col, valuesArray[arrayIndexCounter]);
                arrayIndexCounter++;
            }
        }

    }

    bool MxNValidation(int numberOfRows, int numberOfColumns, int[] arrayForValidation)
    {
       
        int rowsInValidationArray = arrayForValidation.Length / numberOfColumns;
        int colInValidationArray = arrayForValidation.Length / numberOfRows;
        //Debug.Log(rowsInValidationArray);
        //Debug.Log(colInValidationArray);
        if (rowsInValidationArray == matrixHolder.Count && colInValidationArray == matrixHolder[0].Count) 
            return true;
        else
            return false;
    }

    public bool IsASquareMatrix()
    {
        int totalArrayLength = matrixHolder.Count * matrixHolder[0].Count;
        int rowsInValidationArray = totalArrayLength/ matrixHolder[0].Count;
        int colInValidationArray = totalArrayLength / matrixHolder.Count;
      
        if (rowsInValidationArray == colInValidationArray)
            return true;
        else
            return false;
    }


    public void SetSingleElementAtIndex(int row, int column, int value)
    {
        matrixHolder[row].RemoveAt(column);
        matrixHolder[row].Insert(column, value);
    }

    public int GetSingleElementOfIndex(int row, int column)
    {
        return matrixHolder[row][column];
    }
   
    public void SetRowOfMatrix(int row,int[] rowElements)
    {
        List<int> temp=new List<int>();
        for (int i = 0; i < rowElements.Length; i++)
            temp.Add(rowElements[i]);
        matrixHolder.RemoveAt(row);
        matrixHolder.Insert(row,temp);
    }

    public void SetRowOfMatrixTo(int rowNumber, int valueToSet)
    {
        for (int col = 0; col < matrixHolder[0].Count; col++)
            SetSingleElementAtIndex(rowNumber, col, valueToSet);
    }

    public List<int> GetRowOfMatrix(int row)
    {
        return matrixHolder[row];
    }
    public void SetColumnOfMatrix(int column, List<int> columnElements)
    {
        for (int i = 0; i < columnElements.Count; i++)
            SetSingleElementAtIndex(i, column, columnElements[i]);
    }

    public void SetColumnOfMatrixTo(int colNumber, int valueToSet)
    {
        for (int row = 0; row < matrixHolder[0].Count; row++)
            SetSingleElementAtIndex(row, colNumber, valueToSet);
    }
    public List<int> GetColoumnOfMatrix(int column)
    {
        List<int> temp = new List<int>();
        for (int row = 0; row < matrixHolder.Count; row++)
            temp.Add(GetSingleElementOfIndex(row, column));
        return temp;
    }

    public void SetPrimaryDiagnalTo(int valueToSet)
    {

        for (int row = 0, col=0; row < matrixHolder[0].Count;col++, row++)
            SetSingleElementAtIndex(row, col, valueToSet);
    }

    public List<int> GetPrimaryDiagnal()
    {
        List<int> temp = new List<int>();
        for (int row = 0, col = 0; row < matrixHolder[0].Count; col++, row++)
            temp.Add(GetSingleElementOfIndex(row, col));
        return temp;
    }

    public void SetSecondaryDiagnalTo(int valueToSet)
    {

        for (int row = 0, col = matrixHolder[0].Count-1; col >=0; col--, row++)
            SetSingleElementAtIndex(row, col, valueToSet);
    }

    public List<int> GetSecondaryDiagnal()
    {
        List<int> temp = new List<int>();
        for (int row = 0, col = matrixHolder[0].Count - 1; col >= 0; col--, row++)
            temp.Add(GetSingleElementOfIndex(row, col));
        return temp;
    }

    public void SwapRows(int row1,int row2)
    {
        List<int> temp = new List<int>();
        temp = GetRowOfMatrix(row1);
        SetRowOfMatrix(row1, matrixHolder[row2].ToArray());
        SetRowOfMatrix(row2, temp.ToArray());
    }

    public void SwapColumns(int col1, int col2)
    {
       List<int> temp = new List<int>(matrixHolder[0].Count);
      
        for (int a = 0; a < matrixHolder[0].Count; a++)
            temp.Add(GetColoumnOfMatrix(col1)[a]);
        for (int i = 0; i < temp.Count; i++)
            Debug.Log(temp[i]);
        SetColumnOfMatrix(col1, GetColoumnOfMatrix(col2));
        SetColumnOfMatrix(col2, temp);
    }

     public bool IsRowSame(int value)
    {
        return CheckAllValuesSame(GetRowOfMatrix(value));
    }

    public bool IsColumnSame(int value)
    {
        return CheckAllValuesSame(GetColoumnOfMatrix(value));


    }
    public bool IsPrimaryDiagnalSame()
    {
        return CheckAllValuesSame(GetPrimaryDiagnal());
    }

    public bool IsSecondaryDiagnalSame()
    {
        return CheckAllValuesSame(GetSecondaryDiagnal());
    }

    bool CheckAllValuesSame(List<int> Temp)
    {
        List<int> temp = Temp;
        List<bool> result = new List<bool>();

        for (int i = 0; i < temp.Count; i++)
            result.Add(temp[i] == temp[0]);

        if (result.Contains(false))
            return false;
        else
            return true;
    }

    public Matrix AddMatrix(Matrix matrix)
    {
        Matrix resultantMatrix = new Matrix(matrixHolder.Count, matrixHolder[0].Count);
        for(int row=0; row< matrixHolder.Count; row++)
        {
            for(int col=0;col< matrixHolder[0].Count; col++)
            {
                resultantMatrix.matrixHolder[row][col] = matrixHolder[row][col]+ matrix.matrixHolder[row][col];
            }
        }
        return resultantMatrix;
    }

    public void MultiplyMatrixWith(Matrix matrix)
    {
        
        if (matrixHolder[0].Count == matrix.matrixHolder.Count)
        {
            //Debug.Log(matrixHolder.Count);
            //Debug.Log(matrix.matrixHolder[0].Count);
            Matrix resultantMatrix = new Matrix(matrixHolder.Count, matrix.matrixHolder[0].Count);

            for (int row = 0; row < resultantMatrix.matrixHolder.Count; row++)
            {
                for(int col = 0; col < resultantMatrix.matrixHolder[0].Count; col++)
                {
                    resultantMatrix.SetSingleElementAtIndex(row, col, AdditionalResultOfMultiples(this, matrix));
                }
            }
             resultantMatrix.PrintMatrix();
        }
        else
        Debug.LogError("matrices size is not fit for multiplication- It should be (mxn)(nxr) or (mxn)(nxm)");
    }
    int AdditionalResultOfMultiples(Matrix matrix1,Matrix matrix2)
    {
        int result = 0;
        for (int row=0;row< matrix1.matrixHolder.Count; row++)
        {
            List<int> rowElements = GetRowOfMatrix(row);
            for (int col = 0; col < matrix2.matrixHolder[0].Count; col++)
            {
                List<int> colElements = GetColoumnOfMatrix(col);
                List<int> temp = new List<int>();
                for(int i = 0; i < rowElements.Count; i++) 
                temp.Add(rowElements[i] * colElements[i]);
               
                for (int i = 0; i < temp.Count; i++)
                    result += temp[i];
            }
        }

        return result;
    }

    public void PrintMatrix()
    {
        string matrixDisplay = "";
        for (int rows = 0; rows < matrixHolder.Count; rows++)
        {

            for (int col = 0; col < matrixHolder[rows].Count; col++)
            {
                matrixDisplay+=matrixHolder[rows][col]+"  ";
            }
            matrixDisplay += "\n";
        }
        Debug.Log(matrixDisplay);
    }

}
