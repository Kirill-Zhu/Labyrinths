using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QustionsGameController : MonoBehaviour
{
    [SerializeField] private MiniGameManager _miniGameManager;
    public Dialogue dialogues;
    [SerializeField] private Chuvak _chuvak;
    [SerializeField] private List<QuestionPage> _pages;
    [SerializeField] private Button _buttonBack;
    [SerializeField] private Button _buttonHome;


    private int _currentPageIndex;
    private void OnEnable()
    {
        OpenPage(0);
    }

    public void OpenPage(int index)
    {
        _currentPageIndex = index;
        if (index == 0)
        {
            _chuvak.EnableChuvaka();
            _chuvak.ChangeText(dialogues.Text[0]);
        }
        else if(index == _pages.Count-1)
        {
            _chuvak.EnableChuvaka();
            _chuvak.ChangeText(dialogues.Text[1]);
        }
    else
        {
            _chuvak.DiasableChuvaka();
        }
            

        foreach (var page in _pages)
            if (page.gameObject.activeInHierarchy)
                page.gameObject.SetActive(false);

        _pages[index].gameObject.SetActive(true);
        _pages[index].Reset();
    }

    public void GoToMiniGameMenu()
    {
      
        gameObject.SetActive(false);
        _miniGameManager.OpenGameManagerMenu();
    }
    public void PreviousPage()
    {
        try
        {
            OpenPage(_currentPageIndex - 1);
        }
        catch
        {
            OpenPage(0);
        }
    }
}
