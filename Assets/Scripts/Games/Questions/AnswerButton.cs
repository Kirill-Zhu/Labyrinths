using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace QuestionGame {
    [RequireComponent(typeof(Image))]
     public class AnswerButton : MonoBehaviour
    {
        public bool IsRigth;
        public bool IsChoosed;
    
        public QuestionPage _questionPage;
        [SerializeField] private Sprite _idleSprite;
        [SerializeField] private Sprite _chossedSprite;
        [SerializeField] private Sprite _rightSprite;
        [SerializeField] private Sprite _wrongSprite;

        private Image _image;
        private Button _button;

        private void Awake()
        {
            _image = GetComponent<Image>();
            _button = GetComponent<Button>();
            SetStartState();

        }
        public void Reset()
        {
            IsChoosed = false;

            _image.sprite = _idleSprite;
            _image.color = Color.white;
            if (IsRigth)
                _questionPage.currentGoals--;

            _button.onClick.RemoveAllListeners();
            _button.onClick.AddListener(() => Chose());
        }
      
        public void Chose()
        {
            if(_questionPage.OneAsnswer)          
                _questionPage.ResetAsnwerButtons();
          
            IsChoosed = true;
            _image.sprite = _chossedSprite;
            if (IsRigth)
                _questionPage.currentGoals++;

            _button.onClick.RemoveAllListeners();
            _button.onClick.AddListener(() => Reset());

        }
        public void Answer()
        {
            
            if (IsRigth&&IsChoosed)
                _image.sprite = _rightSprite;
            if(!IsRigth&&IsChoosed)
                _image.sprite = _wrongSprite;
            
        }

        private void SetStartState()
        {
            IsChoosed = false;

            _image.sprite = _idleSprite;
            _image.color = Color.white;


            _button.onClick.RemoveAllListeners();
            _button.onClick.AddListener(() => Chose());
        }
    }

}


