using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CellView :MonoBehaviour
{
    public Cell cell;
    // Start is called before the first frame update
    private void OnEnable()  
    {
        SetStatus(Cell.Status.outerarea);
       
    }
    
    public void SetCell(Cell createdCell)
    {
        cell = createdCell;
        CellInitializer();
    }

  
    public void CellInitializer()
    {
        cell.statusUpdate += SetStatus;
    }

 

    public void SetStatus(Cell.Status currentStatus)
    {
        switch (currentStatus)
        {
            case Cell.Status.outerarea:
                break;
            case Cell.Status.ownedArea:
                ChangeReginColour();
                break;
        }
  
    }

    private void ChangeReginColour()
    {
        this.gameObject.GetComponent<Image>().color = Color.red;
    }

   
}
