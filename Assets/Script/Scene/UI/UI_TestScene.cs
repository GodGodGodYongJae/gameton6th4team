
using Script.Manager.Contents;
using UnityEngine;

public class UI_TestScene :UI_Scene
{
    public override bool Init()
    {
        if (base.Init() == false)
            return false;
        
        PreResourceLoad();
        return true;
    }

    #region ResourceLoad
    private bool isPreload = false;

    private void PreResourceLoad()
    {
        Managers.Resource.LoadAllAsync<Object>(Define.ResourceLabel.PreLoad.ToString(), (key, count, totalCount) =>
        {
            Debug.Log("Load");
            if (totalCount == count)
            {
                Debug.Log("end");
                isPreload = true;
                Managers.Resource.Load<GameObject>("Note", (success) =>
                {
                    Managers.Game.Note = Object.Instantiate(success, this.transform).GetComponent<Note>();
                });
            }
            
        });
    }

    #endregion

}
