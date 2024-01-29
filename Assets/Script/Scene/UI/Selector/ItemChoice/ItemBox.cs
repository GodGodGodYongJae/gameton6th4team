
    using System;
    using UnityEngine;
    using UnityEngine.UI;

    public class ItemBox : MonoBehaviour
    {
        [SerializeField] private GameObject _scratchImage;
        private Sprite _sprite;
        public Sprite GetSprite => _sprite;
        private Button _button;
        public void Init(Sprite sprite,Action action,Flag flagAction,bool enableChoice)
        {
            _sprite = sprite;
            _scratchImage.SetActive(!enableChoice);
            _button = Utils.GetOrAddComponent<Button>(this.gameObject);
            _button.onClick.AddListener(() =>
            {
                if (!enableChoice) 
                    return;
                
                Managers.Game.SetFlag(flagAction);
                action?.Invoke();
            });
        }
        private void Start()
        {
            _sprite = GetComponent<Sprite>();
        }
        
    }
