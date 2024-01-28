using UnityEngine;

public class UseEffectSetStatus : UseEffect
{
     private float _value;
     private Define.SetStatusAction _setStatusAction;
     private Define.CharacterStatus _characterStatus;

     public UseEffectSetStatus(Define.SetStatusAction actionStatus, Define.CharacterStatus characterStatus, float value)
     {
         _value = value;
         _setStatusAction = actionStatus;
         _characterStatus = characterStatus;
     }

     public override void UseItem(Character useCharacter)
     {
         Utils.CalculateCharacterStatusValue(useCharacter, _setStatusAction, _characterStatus, _value);
     }
     
     
}