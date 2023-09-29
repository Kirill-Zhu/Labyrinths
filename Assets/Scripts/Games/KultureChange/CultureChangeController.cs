using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace KultureChange {

    public class CultureChangeController : MonoBehaviour
    {
        [SerializeField] private MiniGameManager _miniGameManager;
        [SerializeField] private int _currentPageIndex;
        [SerializeField] private int _try;
        [SerializeField] private int _mistakes;

        [SerializeField] private List<Card> _cards;

        [Header("Buttons")]
        [SerializeField] private ApplyButton _applyButton;
        [SerializeField] private Button _homeButton;
        [SerializeField] private Button _backButton;
        [SerializeField] private Button _goodEndButton;
        [SerializeField] private Button _retryButton;
        [SerializeField] private Button _toNewExplorations;


        [SerializeField] private Chuvak _chuvak;
        public Dialogue PageDialogues;
        public Dialogue WinDialogue;
        public Dialogue LooseDialogue;
        public Dialogue FinalDialogue;


        private async void OnEnable()
        {
            await Task.Delay(100);
            StartGame();
        }
        [ContextMenu("Start Game")]
        public void StartGame()
        {
            _try = 0;
            _mistakes = 0;
            _currentPageIndex = 0;

            SetMainMenuCards();
            SetApplyButtonStartState();

            CloseFinalButtons();

            _applyButton.gameObject.SetActive(true);
            _applyButton.Button.onClick.RemoveAllListeners();
            _applyButton.Button.onClick.AddListener(() => NextRound());

            ChuvakPageDialogue(_currentPageIndex);
        }
        public void NextRound()
        {
            try
            {
                _try = 0;
                _currentPageIndex++;


                RandomizeCards();
                SetApplyButtonStartState();
                SetStandartCardback();

                _applyButton.Button.onClick.RemoveAllListeners();
                _applyButton.Button.onClick.AddListener(() => CheckForWin());

                ChuvakPageDialogue(_currentPageIndex);
            }
           catch
            {
                ResultRound();
            }
        }
        public void PreviousRound()
        {
            try
            {
                _try = 0;
                _currentPageIndex--;


                RandomizeCards();
                SetApplyButtonStartState();
                SetStandartCardback();

                CloseFinalButtons();
                _applyButton.gameObject.SetActive(true);
                _applyButton.Button.onClick.RemoveAllListeners();
                _applyButton.Button.onClick.AddListener(() => CheckForWin());

                ChuvakPageDialogue(_currentPageIndex);
            }
            catch
            {
                StartGame();
            }  
        }
        
       
        public void RetryRound()
        {
            _try++;


            RandomizeCards();
            SetApplyButtonStartState();
            SetStandartCardback();

            _applyButton.Button.onClick.RemoveAllListeners();
            _applyButton.Button.onClick.AddListener(() => CheckForWin());

            ChuvakPageDialogue(_currentPageIndex);
        }

        public void CheckForWin()
        {
            foreach (var card in _cards)
                if (card.CurrentIconIndex != _currentPageIndex)
                {
                    card.SetBackRed();
                }
                else
                {
                    card.SetBackGreen();
                }
                
            for(int i = 0; i<_cards.Count; i++)
            {
                if(_cards[i].CurrentIconIndex!= _currentPageIndex)
                {
                    if (_try < 2)
                    {
                        SetApplyButtonRetryState();

                        _applyButton.Button.onClick.RemoveAllListeners();
                        _applyButton.Button.onClick.AddListener(() => RetryRound());

                        _chuvak.ChangeText(LooseDialogue.Text[_currentPageIndex]);
                    }
                    else
                    {
                        ShowRightAnswers();

                        SetApplyButtonNextState();

                        _applyButton.Button.onClick.RemoveAllListeners();
                        _applyButton.Button.onClick.AddListener(() => NextRound());

                        _chuvak.ChangeText(WinDialogue.Text[_currentPageIndex]);
                    }
                    _mistakes++;
                    return;
                }
            }
            
            SetApplyButtonNextState();
                
            _applyButton.Button.onClick.RemoveAllListeners();
            _applyButton.Button.onClick.AddListener(() => NextRound());

            _chuvak.ChangeText(WinDialogue.Text[_currentPageIndex]);
        }
        public void GoToMiniGameMenu()
        {
            gameObject.SetActive(false);
            _miniGameManager.OpenGameManagerMenu();
        }
        private void ResultRound()
        {
            if(_mistakes<4)
            {
                _applyButton.gameObject.SetActive(false);
                _goodEndButton.gameObject.SetActive(true);
                _chuvak.ChangeText(FinalDialogue.Text[0]);
            }
            else
            {
                _applyButton.gameObject.SetActive(false);

                _retryButton.gameObject.SetActive(true);
                _toNewExplorations.gameObject.SetActive(true);

                _chuvak.ChangeText(FinalDialogue.Text[1]);
            }
        }
        
        #region ApplyButton
         public void SetApplyButtonStartState()
        {
            _applyButton.SetApplyIcon();
            _applyButton.Button.onClick.RemoveAllListeners();
            //_applyButton.Button.onClick.AddListener(()=> )
        }
        public void SetApplyButtonNextState()
        {
            _applyButton.SetNextRoundIcon();
            _applyButton.Button.onClick.RemoveAllListeners();
        }
        public void SetApplyButtonRetryState()
        {
            _applyButton.SetRetryRoundIcon();
            _applyButton.Button.onClick.RemoveAllListeners();

        }
        #endregion
        #region Cards
        [ContextMenu("Set Main Menu Cards")]
        public void SetMainMenuCards()
        {
            foreach (var card in _cards)
                card.SetCard(0);
        }

        [ContextMenu("Randomize Cards")]
        public void RandomizeCards()
        {
            foreach (var card in _cards)
                card.SetRandomCard();
        }
        public void SetStandartCardback()
        {
            foreach (var card in _cards)
                card.SetBackStandart();
        }
        public void ShowRightAnswers()
        {
            foreach (var card in _cards)
            {
                card.SetCard(_currentPageIndex);
                card.SetBackGreen();
            }
                
        }
        #endregion
        #region Chuvak
        public void ChuvakPageDialogue(int index)
        {
            _chuvak.ChangeText(PageDialogues.Text[index]);
        }
        #endregion
        #region FinalButtons
        private void CloseFinalButtons()
        {
            _goodEndButton.gameObject.SetActive(false);
            _retryButton.gameObject.SetActive(false); 
            _toNewExplorations.gameObject.SetActive(false);
        }
        #endregion
    }
}



