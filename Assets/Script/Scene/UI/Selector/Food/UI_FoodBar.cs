using System;
using System.Linq;
using Script.Scene.UI.Selector.Food;
using Sirenix.OdinInspector;
using TMPro;
using UniRx;
using UniRx.Triggers;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


    public class UI_FoodBar : SerializedMonoBehaviour,IFoodDistribute
    {
        #region  property

        [SerializeField]
        private TextMeshProUGUI _overFoodText;

        [SerializeField] private string _itemName;

        [SerializeField] private float _clickAmount;

        public float GetClickAmount => _clickAmount;
        [SerializeField] private FoodType _foodType;

        FoodType IFoodDistribute.GetFoodType() => _foodType;
        public FoodType GetFoodType => _foodType; 
        public string GetItemName => _itemName;
        
        private float _currentFood = 0f;

        private Image _image;

        private const float MaxValue = 6.0f;


        #endregion
        
        
        private int _districbuteCurrentCount = 0;

        private void Awake()
        {
            _image = GetComponent<Image>();
            this.UpdateAsObservable().Select(_ => _currentFood).Subscribe(x => ShowAmountUpdate());
        }

        private void SetCurrentAmount()
        {
            if (Managers.Game.GetFindByItemName(_itemName) is ICountableItem item)
            {
                _currentFood = item.GetAmount();
            }
       
        }

        public void NextDay()
        {
            _districbuteCurrentCount = 0;
            SetCurrentAmount();
        }
        private void DistributeItem()
        {
            if (Managers.Game.Characters.Count(character => character.GetIsAlive) <= _districbuteCurrentCount)
            {
                CancelDistributeItem();
                return;
            }
            
            if ( _currentFood < _clickAmount * Managers.Game.Characters.Count(character => character.GetIsAlive))
            {
                return;
            }
            
            _currentFood -= _clickAmount * Managers.Game.Characters.Count(character => character.GetIsAlive);
        }

        private void CancelDistributeItem()
        {
            if (_districbuteCurrentCount == 0)
            {
                DistributeItem();
                return;
            }
            _currentFood += _clickAmount * Managers.Game.Characters.Count(character => character.GetIsAlive);
            _districbuteCurrentCount = 0;
        }
        private void ShowAmountUpdate()
        {
            _image.fillAmount = _currentFood / MaxValue;
        }



        public void CharacterFoodDistribute()
        {
            _districbuteCurrentCount++;
            _currentFood -= _clickAmount;
        }

        public void CharacterFoodBackIn()
        {
            _districbuteCurrentCount--;
            _currentFood += _clickAmount;
        }
    }
