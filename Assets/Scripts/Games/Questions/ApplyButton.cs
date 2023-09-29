using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace QuestionGame
    {
    [RequireComponent(typeof(Button))]
    internal class ApplyButton : MonoBehaviour
    {

        public Button button;

        [SerializeField] private Sprite _applySprite;
        [SerializeField] private Sprite _nextPageSprite;
        [SerializeField] private Sprite _resteSprite;

        [SerializeField] private Image _image;
        private void Awake()
        {
            button = GetComponent<Button>();
            _image = GetComponent<Image>();
        }
        public void SetApplySrite()
        {
            _image.sprite = _applySprite;
        }
        public void SetNextPageSprite()
        {
            _image.sprite = _nextPageSprite;
        }
        public void SetResetSrpite()
        {
            _image.sprite = _resteSprite;
        }
    }

}


