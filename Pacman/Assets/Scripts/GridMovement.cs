using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridMovement : MonoBehaviour
{
    

    public static List<List<Cell>> cellss = new List<List<Cell>>();
    public static Vector2 CurrentCellIndex=new Vector2(0,0);
 
    // Update is called once per frame
    void Update()
    {
        Moving();
    }

    void Moving()
    {
        if (cellss.Count == 0)
        {
            Debug.Log("Grid is not connected");
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.RightArrow) && CurrentCellIndex.y < cellss[0].Count-1)
            {
                transform.position = cellss[(int)CurrentCellIndex.x][(int)CurrentCellIndex.y + 1].GetCellPosition();
                 CurrentCellIndex = new Vector2(CurrentCellIndex.x, CurrentCellIndex.y + 1);
                cellss[(int)CurrentCellIndex.x][(int)CurrentCellIndex.y].CellInteraction();

            }
            if (Input.GetKeyDown(KeyCode.LeftArrow) && CurrentCellIndex.y > 0)
            {
                transform.position = cellss[(int)CurrentCellIndex.x][(int)CurrentCellIndex.y - 1].GetCellPosition();
                CurrentCellIndex = new Vector2(CurrentCellIndex.x, CurrentCellIndex.y - 1);
                cellss[(int)CurrentCellIndex.x][(int)CurrentCellIndex.y].CellInteraction();
            }
            if (Input.GetKeyDown(KeyCode.UpArrow) && CurrentCellIndex.x > 0)
            {
                transform.position = cellss[(int)CurrentCellIndex.x-1][(int)CurrentCellIndex.y].GetCellPosition();
                CurrentCellIndex = new Vector2(CurrentCellIndex.x-1, CurrentCellIndex.y);
                cellss[(int)CurrentCellIndex.x][(int)CurrentCellIndex.y].CellInteraction();
            }
            if (Input.GetKeyDown(KeyCode.DownArrow) && CurrentCellIndex.x < cellss.Count - 1)
            {
                transform.position = cellss[(int)CurrentCellIndex.x+1][(int)CurrentCellIndex.y].GetCellPosition();
                CurrentCellIndex = new Vector2(CurrentCellIndex.x+1, CurrentCellIndex.y);
                cellss[(int)CurrentCellIndex.x][(int)CurrentCellIndex.y].CellInteraction();
            }
        }
    }
}
