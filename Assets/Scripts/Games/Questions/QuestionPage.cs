using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using QuestionGame;


public class QuestionPage : MonoBehaviour
{
   
    
    public int currentGoals;
    public bool OneAsnswer;
    [SerializeField] private int _curentPageIndex;
    [SerializeField] QustionsGameController _qustionsGameController;
  
    [SerializeField] private int GoalsNeedToGoNext;
    [SerializeField] private List<AnswerButton> _answerButtons;
    public Queue<AnswerButton> _chosedAsnwerButtons = new Queue<AnswerButton>();

    [SerializeField] private ApplyButton _applyButton;

    private void Start()
    {
        _applyButton.button.onClick.RemoveAllListeners();
        _applyButton.button.onClick.AddListener(() => Answer());
        _applyButton.SetApplySrite();
    }
    public void Answer()
    {
        foreach (var butt in _answerButtons)
            butt.Answer();

        if(currentGoals == GoalsNeedToGoNext)
        {
            _applyButton.button.onClick.RemoveAllListeners();
            _applyButton.button.onClick.AddListener(() => GoNext());
            _applyButton.SetNextPageSprite();
        }
        else
        {
            _applyButton.button.onClick.RemoveAllListeners();
            _applyButton.button.onClick.AddListener(() => Reset());
            _applyButton.SetResetSrpite();
        }
    }
    public void ResetAsnwerButtons()
    {
        foreach (var answer in _answerButtons)
            if (answer.IsChoosed)
                answer.Reset();
    }
    public void GoNext()
    {
        _qustionsGameController.OpenPage(_curentPageIndex +1);
    }
    public void Reset()
    {
        _applyButton.SetApplySrite();
        _applyButton.button.onClick.RemoveAllListeners();
        _applyButton.button.onClick.AddListener(() => Answer());
        
       

        foreach (var butt in _answerButtons)
            butt.Reset();

        currentGoals = 0;
    }
}
