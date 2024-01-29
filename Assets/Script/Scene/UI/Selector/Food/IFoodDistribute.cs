
    using Script.Scene.UI.Selector.Food;

    public interface IFoodDistribute
    {
        public FoodType GetFoodType();
        public void CharacterFoodDistribute();
        public void CharacterFoodBackIn();
        public bool CheckFoodDistribute();
    }
