using System;
using System.Collections.Generic;
using Script.Scene.UI.Selector.Food;
using Sirenix.OdinInspector;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FoodCharacterItem : SerializedMonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _displayStatus;

        [SerializeField] private PersonInfo _personInfo;

        private List<IFoodDistribute> _foodBarDistributes = new List<IFoodDistribute>();

        private bool _isAlive = true;

        [SerializeField] private Dictionary<FoodType, Toggle> _foodToggles = new Dictionary<FoodType, Toggle>();
        
        //TODO Item Image Show  isEatFood isEatWater

        private void Start()
        {
            foreach (var (foodType, value) in _foodToggles)
            {
                value.onValueChanged.AddListener(_=>
                {
                    OnFoodToggle(foodType,value);
                });
            }
        }

        private void OnFoodToggle(FoodType foodType, Toggle toggle)
        {  
            var foodDistribute = _foodBarDistributes.Find(x => x.GetFoodType() == foodType);
            if (toggle.isOn)
            {
                foodDistribute.CharacterFoodDistribute();
            }
            else
            {
                foodDistribute.CharacterFoodBackIn();
            }

        }
        public void SetFoodBarDistribute(List<IFoodDistribute> foodDistributes)
        {
            _foodBarDistributes = foodDistributes;
        }
        
        public void SetDisplayStatusText(string text)
        {
            _displayStatus.text = text;
        }

        public void SetPersonInfoSprite(Sprite sprite)
        {
            _personInfo.SetPersonInfo(sprite);
        }

        public void SetAliveCharacterInfo(bool isAlive)
        {
            _isAlive = isAlive;
        }
    }
