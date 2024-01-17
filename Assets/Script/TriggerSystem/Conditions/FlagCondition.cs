
using UnityEngine;
    
public class FlagCondition : Condition
    {
        public string name;
        public int flag;
        public override bool CheckCondition()
        {
            Debug.Log(name + flag + "flag Condition");
            return true;
        }
    }
