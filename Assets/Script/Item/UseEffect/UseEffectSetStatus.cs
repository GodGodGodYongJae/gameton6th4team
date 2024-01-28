using UnityEngine;

public class UseEffectSetStatus : UseEffect
{
    [SerializeField] private int value;
    [SerializeField] private Define.SetStatusAction SetStatusAction;
    [SerializeField] private Define.CharacterStatus characterStatus;
    public override void UseItem()
    {
        // Managers.Game.set 아이템을 썼을 때 대상? 선택은 어떻게 할레 .
    }
}