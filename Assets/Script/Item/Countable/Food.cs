
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/Food/CountableItem/Food", order = 4 , fileName = "Food_")]
public class Food : ICountableItem, IEat
{
    public int GetHunger = 0;

    public void Eat(ICharacter character)
    {
        character.SetHunger(character.GetHunger() + GetHunger);
    }

    private int _amount = 0;

    public int GetAmount()
    {
        return _amount;
    }

    [SerializeField]
    private int _maxAmount = 0;

    public int GetMaxAmount()
    {
        return _maxAmount;
    }

    public void SetAmount(int amount)
    {
        if (amount >= _maxAmount)
        {
            _amount = _maxAmount;
            return;
        }

        _amount = amount;
    }
}
