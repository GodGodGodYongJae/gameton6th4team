
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
        //ShowCharacterStatus.
      
        CurrentDay++;
        _triggerEvent.StartTrigger(()=>
        {
            ShowCharacterText();
            EndNote();
        });

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


    public void AddTextNote(string text)
    {
        Book.AddText(text+"\n");
       // Note.AddCurrentPageText(text);
    }

    #endregion

    #region CharacterText

    public List<Character> Characters{get; private set; } = new List<Character>();

    public void AddCharacter(Character character)
    {
        Characters.Add(character);
    }

    private void InitCharacterText()
    {
        foreach (var character in Characters)
        {
            character.StatusText.Clear();
            character.DisplaySatus.Clear();
        }
    }
    private void ShowCharacterText()
    {
        InitCharacterText();
        CheckStatus();
        foreach (var character in Characters)
        {
            if (!character.GetIsAlive)
            {
                continue;
            }

            foreach (var statusText in character.StatusText)
            {
                AddTextNote(statusText);
            }
        }
    }

    #endregion

    private void CheckStatus()
    {
        foreach (var status in Managers.Data.CharacterStatusDatas)
        {
            var checkStatus = status.Value.status;
            var checkMinValue = status.Value.minValue;
            var checkMaxValue = status.Value.maxValue;
            var noteText = status.Value.text;
            var displayText = status.Value.display;
            foreach (var character in Characters)
            {
                if (Utils.InRange(character.GetStatusValue(checkStatus),checkMinValue,checkMaxValue) )
                {
                    character.StatusText.Add(character.GetName() + noteText);
                    character.DisplaySatus.Add(displayText);
                    
                }
             
            }
        }
    }
}
