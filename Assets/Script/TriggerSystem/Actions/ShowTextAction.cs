
using System;

public class ShowTextAction : TriggerAction
{
    private int? _textNumber;
    public override void RunAction()
    {
        if(_textNumber == null)
            throw new Exception("Not Found TextNumber");
        
        Managers.Game.ShowNotePage((int)_textNumber);
    }
}
