using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Script.Scene.UI.Selector
{
    public class FoodSelector : Selector
    {
        private Dictionary<Character,FoodCharacterItem> _characterList = new Dictionary<Character, FoodCharacterItem>();
        [SerializeField] private List<UI_FoodBar> _foodBars = new List<UI_FoodBar>();

        [SerializeField]
        private GameObject _characterContent;
        private void Start()
        {
            foreach (var character in Managers.Game.Characters)
            {
                Managers.Resource.Load<GameObject>("FoodSelector", (success) =>
                {
                    var infoItem = Object.Instantiate(success, _characterContent.transform).GetComponent<FoodCharacterItem>();
                     _characterList.Add(character,infoItem);
                });
            }

            FoodBarSetting();

        }

        private void FoodBarSetting()
        {
            foreach (var bars in _foodBars)
            {
                bars.SetClickAction(() =>
                {
                    switch (bars.GetItemName)
                    {
                        case "CanFood" :
                            
                            break;
                        case "Water" :
                            break;
                        default:
                            break;
                    }
                });
            }
        }
        public override void NextDay()
        {
               //TODO FOOD 정산, Character Status 정산 ect .. 
        }

        public override void ShowCurrentDay()
        {
            //TODO 현재 식량 , 현재 캐릭터 상태값 표기.
           ShowDisplayStatusText();
           CurrentFoodBarUpdate();
        }

        private void CurrentFoodBarUpdate()
        {
            foreach (var foodBar in _foodBars)
            {
                foodBar.SetCurrentAmount();
            }
        }
        private void ShowDisplayStatusText()
        {
            foreach (var character in _characterList)
            {
                string text = "";
                foreach (var displayStatus in character.Key.DisplayStatusText)
                {
                    text += displayStatus;
                }
                character.Value.SetDisplayStatusText(text);
            }
        }
    }
}