
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

    public void AddCountableItem(Item item, float amount)
    {
        ICountableItem itemCountable;
        if (!GetItemList.ContainsKey(item.GetName))
        {
            GetItemList.Add(item.GetName,item);
            itemCountable = (ICountableItem)item;
            itemCountable.SetAmount(amount);
            return;
        }

        itemCountable =  (ICountableItem)GetItemList[item.GetName];
        itemCountable.SetAmount(itemCountable.GetAmount() + amount);
    }

    public void UseCountableItem(Item item, float amount,Character character)
    {
        ICountableItem itemCountable;
        if (!GetItemList.ContainsKey(item.GetName))
        {
            return;
        }

        itemCountable = (ICountableItem)GetItemList[item.GetName];
        GetItemList[item.GetName].UseItem(character);
        itemCountable.SetAmount(itemCountable.GetAmount() - amount);
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
