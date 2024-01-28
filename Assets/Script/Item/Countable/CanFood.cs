namespace Script.Item.Countable
{
    public class CanFood : EatItem
    {
        public CanFood()
        {
            this.useEffect = new UseEffectSetStatus(Define.SetStatusAction.Add , Define.CharacterStatus.Hungry , 1);
            this._name = "CanFood";
        }

    }
}