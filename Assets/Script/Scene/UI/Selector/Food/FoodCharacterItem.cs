using TMPro;
using UnityEngine;

namespace Script.Scene.UI.Selector
{
    public class FoodCharacterItem : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _displayStatus;

        [SerializeField] private PersonInfo _personInfo;

        public bool isEatFood = false;
        public bool isEatWater = false;
        
        //TODO Item Image Show  isEatFood isEatWater
        
        public void SetDisplayStatusText(string text)
        {
            _displayStatus.text = text;
        }

        public void SetPersonInfoSprite(Sprite sprite)
        {
            _personInfo.SetPersonInfo(sprite);
        }
    }
}