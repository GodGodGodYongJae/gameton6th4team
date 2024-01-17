using System;
using UnityEngine;

[Serializable]
public class DayCondition : Condition
{

    public int startDay;
    public int endDay;
    public override bool CheckCondition()
    {
        Debug.Log($"{startDay}{endDay} DayCondition");
        return Utils.InRange(Managers.Game.CurrentDay, startDay, endDay);
    }
}
