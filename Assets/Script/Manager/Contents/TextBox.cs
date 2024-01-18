using System;
using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;

namespace Script.Manager.Contents
{
    public class TextBox : MonoBehaviour
    {
        private Vector2 _boxSize;
        private RectTransform _rectTransform;
        [SerializeField] private TMP_Text  _viewText;
        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
            _boxSize = _rectTransform.sizeDelta;

        }
        

        public void SetText(string text)
        {
            _viewText.text = text;
        }

        public int GetPageCount()
        {
            return _viewText.textInfo.pageCount;
        }

        public int GetHeightSize()
        {
            return (int)_boxSize.y;
        }

        public void SetHeightBox()
        {
            if (GetPageCount() == 0)
            {
                SyncSize(() =>
                { 
                    Debug.Log("-"+GetPageCount());
                    _rectTransform.sizeDelta = new Vector2(_boxSize.x, _boxSize.y + (GetPageCount() * 50));
                }).Forget();
            }
     
        }

        // 생성 후 바로 PageCount가 반영이 안댐...
        async UniTaskVoid SyncSize(Action callback)
        {
            Debug.Log("dd");
            await UniTask.WaitUntil(() => GetPageCount() != 0);
            callback?.Invoke();
            
        }
    }
}