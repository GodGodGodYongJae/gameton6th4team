using System;
using TMPro;
using UnityEngine;

namespace Script.Manager.Contents
{
    public class TextBox : MonoBehaviour
    {
        private Vector2 _boxSize;
        private RectTransform _rectTransform;
        [SerializeField] private TMP_Text   _viewText;
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

        public void SetHeightBox(int value)
        {
            _rectTransform.sizeDelta = new Vector2(_boxSize.x, _boxSize.y + value);
        }
    }
}