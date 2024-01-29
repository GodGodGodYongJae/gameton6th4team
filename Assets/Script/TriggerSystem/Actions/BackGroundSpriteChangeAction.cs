
    public class BackGroundSpriteChangeAction : TriggerAction
    {
        public string spriteName;
        public override void RunAction()
        {
            Managers.Game.BackGroundChange(spriteName);
        }
    }
