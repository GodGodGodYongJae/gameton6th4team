
using System;
using UnityEngine;

public class ShowTextAction : TriggerAction
{
    public int textNumber;
    public override void RunAction()
    {
        Managers.Game.ShowNotePage(textNumber);
    }
}
