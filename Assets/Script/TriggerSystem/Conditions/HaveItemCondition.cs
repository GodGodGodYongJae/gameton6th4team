
// 해당 아이템을 몇 개 가지고 있는지
    public class HaveItemCondition : Condition
    {
        public int ItemId;
        public int Amount;
        public override bool CheckCondition()
        {
            return Managers.Game.CheckHaveItem(ItemId,Amount);
        }
    }
