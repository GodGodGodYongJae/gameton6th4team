using UnityEngine;

[CreateAssetMenu(fileName = "NewEatItem", menuName = "Items/EatItem")]
    public class EatItem :Item, ICountableItem
    {
        private float _amount;

        [SerializeField] private UseEffectSetStatus _useEffectSetStatus;

        public override void UseItem(Character character)
        {
            this.useEffect = _useEffectSetStatus;
            base.UseItem(character);
        }

        public float GetAmount()
        {
            return _amount;
        }

        public float GetMaxAmount()
        {
            return 0;
        }

        public void SetAmount(float amount)
        {
            _amount = amount;
        }


    }
