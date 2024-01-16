
using System;
/// <summary>
/// 일자 조건
/// </summary>
public class DayCondition : Condition
{
    private const int EMPTY_START_DAY = 0;
    private const int EMPTY_END_DAY = Int32.MaxValue;
    
    private int _startDay;
    private int _endDay;

    public void Init(int startDay = EMPTY_START_DAY, int endDay = EMPTY_END_DAY)
    {
        _startDay = startDay;
        _endDay = endDay;
    }
    
    public override bool CheckCondition()
    {
        return Utils.InRange(Managers.Game.CurrentDay, _startDay, _endDay);
    }
}
