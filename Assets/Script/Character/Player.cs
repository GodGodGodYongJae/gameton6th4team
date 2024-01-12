using System;
using UnityEngine;

public class Player : MonoBehaviour, ICharacter
{
    private int _hunger = 0;
    public int GetHunger()
    {
        return _hunger;
    }

    public void SetHunger(int hunger)
    {
        _hunger = hunger;
    }

    //TODO : Player가 음식을 섭취하는 것 테스트
}
