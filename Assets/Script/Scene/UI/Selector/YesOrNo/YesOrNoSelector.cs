
    using System;
    using System.Collections.Generic;
    using TMPro;
    using Unity.VisualScripting;
    using UnityEngine;
    using UnityEngine.UI;

    public class YesOrNoSelector : Selector
    {
        
        [SerializeField]
        private TMP_Text _text;

        [SerializeField] private Button _yesButton;
        [SerializeField] private Button _noButton;
        private Flag _trueFlag;
        private Flag _falseFlag;
        private bool _isSelectTrueFlag;
        private Dictionary<string, Selector> _selectors;
        public void Init(string text, Flag trueFlag, Flag falseFlag,Dictionary<string,Selector> selectors,Action nextPageAction)
        {
            _text.text = text;
            _trueFlag = trueFlag;
            _falseFlag = falseFlag;
            _selectors = selectors;
            
            _yesButton.onClick.AddListener(() =>
            {
                _isSelectTrueFlag = true;
                nextPageAction?.Invoke();
            });
            _noButton.onClick.AddListener(() =>
            {
                _isSelectTrueFlag = false;
                nextPageAction?.Invoke();
            });
        }

        private void Awake()
        {
            _yesButton.GetOrAddComponent<Button>();
            _noButton.GetOrAddComponent<Button>();
        }

        public override void ShowCurrentDay()
        {
            
        }

        public override void NextDay()
        {
            Managers.Game.SetFlag(_isSelectTrueFlag ? _trueFlag : _falseFlag);
        }
    }
