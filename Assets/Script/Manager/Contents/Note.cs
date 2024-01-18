using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Script.Manager.Contents
{
    public class Note : MonoBehaviour
    {
        private const float MaxHeightSize = 0;
        
        [SerializeField] private GameObject _content;
        private RectTransform _contentRect;
        
        // 각 노트의 컨텐츠는 우선 GameObject로 관리하고자 함. && 일자가 지나면 삭제 및 새로추가 고려.
        private Dictionary<int, List<GameObject>> _pageContents = new Dictionary<int, List<GameObject>>();
        //TODO NOTE에는 페이지가 존재한다. 
        // 1. NOTE의 현재 세로 사이즈를 알아낸다.
        // 2. 만들어지는 컨텐츠가 영억을 초과하면 다음 페이지에 저장한다.
        // 3. 페이지 변화시 해당 페이지의 컨텐츠를 보여준다.
        // 4. Content는 (Text나 기타 등등에 Component를 하나 붙이자 만들어줄 때 사이즈를 해당 컴포넌트에서 알아서 계산할 수 있도록.)
        
        private void Awake()
        {
            _contentRect = _content.GetComponent<RectTransform>();
        }

        private int _currentPage = 1;
        public void AddCurrentPageText(string text)
        {
            Managers.Resource.Load<GameObject>("TextBox", (success) =>
            {
                GameObject textBoxGo = Object.Instantiate(success,_content.transform);
                TextBox textBox = textBoxGo.GetComponent<TextBox>();
                textBox.SetText(text);
                textBox.SetHeightBox(()=>CheckSize(textBox));
            });
        }

        private void CheckSize( TextBox textBox)
        {
            Debug.Log(_contentRect.sizeDelta.y + textBox.GetHeightSize());
            if (_contentRect.sizeDelta.y + textBox.GetHeightSize() > MaxHeightSize)
            {
                Debug.Log("사이즈 초과");
                return;
            }
            // _pageContents.Add(textBox);
        }

    }
}