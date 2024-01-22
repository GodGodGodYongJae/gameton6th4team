
using System;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private int _id;
    private string _name;
    private bool _isAlive;
    private Sprite _sprite;
    private Dictionary<Define.CharacterStatus, float> _status = new Dictionary<Define.CharacterStatus, float>();
    public float GetStatusHungry => _status[Define.CharacterStatus.Hungry];

    public float GetStatusValue(Define.CharacterStatus status) => _status[status];
    public List<string> StatusText = new List<string>();
    public List<string> DisplaySatus = new List<string>();
    public Dictionary<string, int> Flags = new Dictionary<string, int>();
    public bool GetIsAlive => _isAlive;
    public void Awake()
    {
        _sprite = GetComponent<Sprite>();
        _isAlive = true;
        foreach (Define.CharacterStatus status in Enum.GetValues(typeof(Define.CharacterStatus)))
        {
            _status.Add(status,0);
        }
    }

    public string SetName(string value) => this._name = value;

    public void SetStatusHungry(int value)
    {
        // _status["Hungry"] = value;
    }

    public string GetName() => _name;

    // public void ShowTextRunAction(string text)
    // {
    //     ShowTextAction(text);
    // }
}
