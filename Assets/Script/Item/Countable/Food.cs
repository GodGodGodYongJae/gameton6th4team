
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Food/CountableItem/Food", order = 4 , fileName = "Food_")]
public class Food : ICountableItem
{

    private float _amount = 0;

    public void UseItem(float amount)
    {
        _amount -= amount;
        
    }
    public float GetAmount()
    {
        return _amount;
    }

    [SerializeField]
    private int _maxAmount = 0;

    public float GetMaxAmount()
    {
        return _maxAmount;
    }

    public void SetAmount(float amount)
    {
        if (amount >= _maxAmount)
        {
            _amount = _maxAmount;
            return;
        }

        _amount = amount;
    }

}
