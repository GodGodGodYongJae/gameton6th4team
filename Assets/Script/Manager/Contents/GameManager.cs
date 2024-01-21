
using System.Collections.Generic;
using System.Linq;
using Script.Manager.Contents;
using Unity.VisualScripting;
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

    public int CurrentDay { get; private set; } = 0;
    private TriggerEvent _triggerEvent = null;

    public void NextDay()
    {
        if (_triggerEvent == null)
        {
            GameObject triggerEventObject = new GameObject();
            _triggerEvent = triggerEventObject.GetOrAddComponent<TriggerEvent>();
        }
        CurrentDay++;
        _triggerEvent.StartTrigger(EndNote);

    }

    #endregion

    #region Book

    private Book _book;

    public Book Book
    {
        get => _book;
        set => _book = value;
    }

    //TODO NOTE System

    private void EndNote()
    {
        Book.EndText();
    }
    public void ShowNotePage(int pageNum)
    {
        //TODO : 해당 페이지 넘버를 DataManager를 통해 불러온뒤 오브젝트를 만들어준다. 이후 ...
        // Note.Add
        // Managers.Data.TextDatas[pageNum].text;
    }

    public void AddTextNote(string text)
    {
        Book.AddText(text);
       // Note.AddCurrentPageText(text);
    }

    #endregion
}
