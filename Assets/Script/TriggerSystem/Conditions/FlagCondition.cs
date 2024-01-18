
using UnityEngine;
    
public class FlagCondition : Condition
    {
        public string name;
        public int flag;
        public override bool CheckCondition()
        {
            return true;
        }
    }
