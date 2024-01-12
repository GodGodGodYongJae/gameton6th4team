using System;
using UnityEngine;

public interface IScene {
    public void SceneLoad(Action callBack = null);
    public void AddSceneLoadAction(Action actions);
    public UI_Scene GetUIScene();
}