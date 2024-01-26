using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.UI;


    public class PersonInfo : MonoBehaviour
    {
            private Sprite _portraitSprite;
            private Action _clickAction;

            public void SetPersonInfo(Sprite image,Action clickCallback = null)
            {
                _portraitSprite = image;
                _clickAction = clickCallback;
                this.UpdateAsObservable()
                    .Select(_ => _clickAction)
                    .Subscribe(callbackEvent =>
                    {
                        callbackEvent?.Invoke();
                    });
            }

    }
