
using System.Collections.Generic;
using System.Linq;
using Script.Manager.Contents;
using UnityEngine;

public class GameManager
{
    #region  Inventory

    private Inventory _inventory = new Inventory();

    public List<Item> GetInventoryList()
    {
        return _inventory.GetItemList.Values.ToList();
    }

    public void AddItem(Item item,int amount = 0)
    {
        if (item as ICountableItem != null)
        {
            _inventory.AddCountableItem(item,amount);
        }
        else
        {
            _inventory.AddItem(item);
        }
    }

    #endregion

    #region Day

    public int CurrentDay { get; private set; }
    

    #endregion

    #region Note

    private Note _note;

    public Note Note
    {
        get => _note;
        set => _note = value;
    }

    //TODO NOTE System
    public void ShowNotePage(int pageNum)
    {
        
    }

    #endregion
}
