using UnityEngine;

namespace Script.TriggerSystem.Actions
{
    public class SetRandomFlag : TriggerAction
    {
        public Flag flag;
        public int minValue;
        public int maxValue;


        public override void RunAction()
        {
            flag.value = Random.Range(minValue, maxValue+1);
            Managers.Game.SetFlag(flag);
        }
    }
}