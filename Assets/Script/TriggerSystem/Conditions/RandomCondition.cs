
using UnityEngine;

public class RandomCondition : Condition
{
    public float value;
    public override bool CheckCondition()
    {
        float randomValue = Random.Range(0f, 100f);

        return randomValue <= value;
    }
}
