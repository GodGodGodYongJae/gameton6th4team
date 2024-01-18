
using System;
using System.Collections.Generic;
using Newtonsoft.Json;

[Serializable]
public class Character
{
    public int id;
    public string name;
    [JsonIgnore]
    private bool _isAlive;

    [JsonIgnore] 
    private Dictionary<string, int> _status = new Dictionary<string, int>();

    [JsonIgnore] 
    public int GetStatusHungry => _status["Hungry"];

    public void SetStatusHungry(int value)
    {
        _status["Hungry"] = value;
    }
}
