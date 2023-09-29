using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace KultureChange
{
    [RequireComponent(typeof(Animator))]
    public class Card : MonoBehaviour
    {
        public int CurrentIconIndex = 0;
        [SerializeField] private CardObject _cardObject;
        private Animator _animator;
        private Image _backImage;
        private Image _iconImage;
        private Button _button;


        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _backImage = GetComponent<Image>();
            _iconImage = transform.GetChild(0).GetComponent<Image>();
            
            
            _button = GetComponent<Button>();
            _button.onClick.AddListener(() => NextCard());
        }
        public void SetCard(int index)
        {
            CurrentIconIndex = index;
            try
            {
                _iconImage.sprite = _cardObject.Icons[CurrentIconIndex];
            }
            catch
            {
                CurrentIconIndex = 0;
                _iconImage.sprite = _cardObject.Icons[CurrentIconIndex];
            }
            _iconImage.SetNativeSize();
        }
        [ContextMenu("next Card")]
        public void NextCard()
        {
            try
            {
                CurrentIconIndex++;
                _iconImage.sprite = _cardObject.Icons[CurrentIconIndex];
            }
            catch
            {
                CurrentIconIndex = 0;
                _iconImage.sprite = _cardObject.Icons[CurrentIconIndex];
            }
            _iconImage.SetNativeSize();
        }
        [ContextMenu("Set Random Card")]
        public void SetRandomCard()
        {
            CurrentIconIndex = Random.Range(0, _cardObject.Icons.Count-1);
            try
            {
                _iconImage.sprite = _cardObject.Icons[CurrentIconIndex];
            }
            catch
            {
                CurrentIconIndex = 0;
                _iconImage.sprite = _cardObject.Icons[CurrentIconIndex];
            }
            _iconImage.SetNativeSize();
        }

        public void SetBackStandart()
        {
            _backImage.sprite = _cardObject.BackIcons[0];
        }
        public void SetBackGreen()
        {
            _backImage.sprite = _cardObject.BackIcons[1];
        }
        public void SetBackRed()
        {
            _backImage.sprite = _cardObject.BackIcons[2];
        }
    }
}


