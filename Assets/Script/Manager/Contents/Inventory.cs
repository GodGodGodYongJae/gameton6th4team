
using System.Collections.Generic;

public class Inventory
{
    public Dictionary<string, Item> GetItemList { get; private set; } = new Dictionary<string, Item>();

    public void AddItem(Item Item)
    {
        if (!GetItemList.ContainsKey(Item.GetName))
        {
            GetItemList.Add(Item.GetName,Item);
            return;
        }
        GetItemList[Item.GetName] = Item;
    }

    public void AddCountableItem(Item Item, int amount)
    {
        ICountableItem itemCountable;
        if (!GetItemList.ContainsKey(Item.GetName))
        {
            GetItemList.Add(Item.GetName,Item);
            itemCountable = (ICountableItem)Item;
            itemCountable.SetAmount(amount);
            return;
        }

        itemCountable =  (ICountableItem)GetItemList[Item.GetName];
        itemCountable.SetAmount(itemCountable.GetAmount() + amount);
    }

    public Item FindByItemName(string name)
    {
        if (!GetItemList.ContainsKey(name))
        {
            return null;
        }

        return GetItemList[name];
    }
    
}
