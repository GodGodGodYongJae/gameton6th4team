
using System.Collections.Generic;
using System.Linq;

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
 
}
