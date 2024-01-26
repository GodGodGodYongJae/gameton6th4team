using System;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using Script.Scene.UI.Selector.Food;
using UnityEngine;
using Object = UnityEngine.Object;

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
                    infoItem.SetFoodBarDistribute(_foodBars.Select(bar => (IFoodDistribute)bar).ToList());
                     _characterList.Add(character,infoItem);
                });
            }

        }

        public override void NextDay()
        {
               //TODO FOOD 정산, Character Status 정산 ect ..
                FoodAdjustment();

        }

        private void FoodAdjustment()
        {
            float useFoodCount = 0;
            float useWaterCount = 0;
            foreach (var infoItem in _characterList.Values)
            {
                // 이부분 사용 어마운트로 측정해야 함..
                useFoodCount += infoItem.GetIsEat(FoodType.CanFood) ? _foodBars.First(x => x.GetFoodType == FoodType.CanFood).GetClickAmount : 0;
                

                useWaterCount += infoItem.GetIsEat(FoodType.Water) ? _foodBars.First(x => x.GetFoodType == FoodType.Water).GetClickAmount : 0;
            }
            Debug.Log($"사용한 Food{useFoodCount}, 사용한 Water{useWaterCount}");

            var canFood = Managers.Game.GetFindByItemName("CanFood");
            var water = Managers.Game.GetFindByItemName("Water");
               
            Managers.Game.UseItem(canFood,useFoodCount);
            Managers.Game.UseItem(water,useWaterCount);
            ICountableItem ifood = (ICountableItem)canFood;
            ICountableItem iwater = (ICountableItem)water;
            Debug.Log($"남은 Food{ifood.GetAmount()}, 남은 Water{iwater.GetAmount()}");
        }

        public override void ShowCurrentDay()
        {
            //TODO 현재 식량 , 현재 캐릭터 상태값 표기.
            foreach (var info in _characterList.Values)
            {
                info.SetEatToggle(FoodType.CanFood, false);
                info.SetEatToggle(FoodType.Water, false);
            }
           ShowDisplayStatusText();
           CurrentFoodBarUpdate();
        }

        private void CurrentFoodBarUpdate()
        {
            foreach (var foodBar in _foodBars)
            {
                foodBar.NextDay();
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
