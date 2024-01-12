using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerEx
{
    public IScene currentScene { get; private set; }
    public void setCurrentScene(IScene scene)=> currentScene = scene; 
     
    public void LoadScene(Define.Scene changeScene)
    {
        currentScene.SceneLoad(() =>
        {
            //managerClear랑 Destory가 필요한지는 좀 더 분석 후 넣겠음
            SceneManager.LoadScene(GetSceneName(changeScene));
        });
    }

    
    private string GetSceneName(Define.Scene type)
    {
        string name = System.Enum.GetName(typeof(Define.Scene), type);
        return name;
    }


}