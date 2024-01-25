using Sirenix.OdinInspector;
using UnityEngine;

namespace Script.Scene.UI.Selector
{
    public abstract class Selector : MonoBehaviour
    {
        public abstract void ShowCurrentDay();
        public abstract void NextDay();
    }
}