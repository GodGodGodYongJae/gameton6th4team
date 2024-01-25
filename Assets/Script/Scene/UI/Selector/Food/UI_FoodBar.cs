using System;
using System.Linq;
using TMPro;
using UniRx;
using UniRx.Triggers;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Script.Scene.UI.Selector
{
    public class UI_FoodBar : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _overFoodText;

        [SerializeField] private string _itemName;

        [SerializeField] private float _clickAmount;

        public string GetItemName => _itemName;
        
        private float _currentFood = 0f;

        private Image _image;

        private const float MaxValue = 6.0f;

        private Toggle _toggle;

        private Action _clickAction;
        
        public void SetClickAction(Action action)
        {
            _clickAction = action;
        }
        private void Awake()
        {
            _image = GetComponent<Image>();
            this.UpdateAsObservable().Select(_ => _currentFood).Subscribe(x => ShowAmountUpdate());
            _toggle = this.GetOrAddComponent<Toggle>();
            _toggle.onValueChanged.AddListener(OnChangeToggle);
        }

        private void OnChangeToggle(bool isOn)
        {
            
        }

        public void SetCurrentAmount()
        {
            if (Managers.Game.GetFindByItemName(_itemName) is ICountableItem item)
            {
                _currentFood = item.GetAmount();
            }
       
        }

        private void UseItem()
        {
            //TODO Manager Item Inventory sub
        }

        private bool isDistricbute = false;
        private void DistributeItem()
        {
            if ( _currentFood < _clickAmount * Managers.Game.Characters.Count(character => character.GetIsAlive))
            {
                return;
            }
            
            _currentFood -= _clickAmount * Managers.Game.Characters.Count(character => character.GetIsAlive);
            _clickAction?.Invoke();
        }

        private void CancelDistributeItem()
        {
            _currentFood += _clickAmount * Managers.Game.Characters.Count(character => character.GetIsAlive);
        }
        private void ShowAmountUpdate()
        {
            _image.fillAmount = _currentFood / MaxValue;
        }
    }
}