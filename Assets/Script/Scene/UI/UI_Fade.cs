
    using System;
    using DG.Tweening;
    using TMPro;
    using UnityEngine;
    using UnityEngine.UI;

    //TODO, 
    public class UI_Fade : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _dayText;
        private Image _image;

        private float _time;
        private void Awake()
        {
            _image = GetComponent<Image>();
        }

        private void Start()
        {
            Sequence sequence = DOTween.Sequence()
                .SetAutoKill(false)
                .OnRewind(() =>
                {
                    _image.enabled = true;
                })
                .Append(_image.DOFade(1.0f, _time))
                .Append(_image.DOFade(0.0f, _time))
                .OnComplete(() =>
                {
                    _image.enabled = false;
                });
        }

        public void FadeIn(int currentDay, float time = 1.0f)
        {
            _dayText.text = $"{currentDay} + 일" ;
            _time = time;
            _image.enabled = true;
        }

        public void FadeOut()
        {
            
        }
        
    }
