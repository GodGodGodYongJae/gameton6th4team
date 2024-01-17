
using System;
using UnityEngine;

public class ShowTextAction : TriggerAction
{
    public int textNumber;
    public override void RunAction()
    {
        Debug.Log("ShowTextAction" + textNumber);
        Managers.Game.ShowNotePage(textNumber);
    }
}
