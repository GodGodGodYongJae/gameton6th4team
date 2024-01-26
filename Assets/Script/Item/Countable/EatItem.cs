
    public class EatItem :Item, ICountableItem
    {
        public EatItem(string name)
        {
            this._name = name;
        }
        private float _amount;
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
