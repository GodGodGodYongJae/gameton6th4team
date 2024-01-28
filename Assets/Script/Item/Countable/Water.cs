namespace Script.Item.Countable
{
    public class Water : EatItem
    {
        public Water()
        {
            this.useEffect = new UseEffectSetStatus(Define.SetStatusAction.Add, Define.CharacterStatus.Thirsty, 1);
            this._name = "Water";
        }
    }
}