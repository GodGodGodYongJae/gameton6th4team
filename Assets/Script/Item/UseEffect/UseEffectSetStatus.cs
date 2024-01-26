using UnityEngine;

public class UseEffectSetStatus : UseEffect
{
    [SerializeField] private int value;
    [SerializeField] private Define.SetStatusAction SetStatusAction;
    [SerializeField] private Define.CharacterStatus characterStatus;
    public override void UseItem()
    {
        Managers.Game.set
    }
}