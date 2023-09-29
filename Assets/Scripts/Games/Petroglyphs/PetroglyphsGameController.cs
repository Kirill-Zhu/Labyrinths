using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PetroglyphsGameController : MonoBehaviour
{
    public Dialogue dialogues;
    [SerializeField] private Camera _camera;
    [SerializeField] private Chuvak _chuvak;
    [SerializeField] private Button _buttonBack;
    [Header("Find page")]
    [SerializeField] private GameObject _findGame;
    [SerializeField] private GameObject _findMenu;
    [SerializeField] private List<PetroglyphChekPoint> _checkPoints;

    [Header("Chose ohra page")]
    [SerializeField] private Button _ohraButton;
    [Header("Draw page")]
    [SerializeField] private GameObject _drawGame;
    [SerializeField] private List<Filler> _fillers;
    
    [SerializeField] private MiniGameManager _miniGameManager;
    [Header("Finnaly page")]
    [SerializeField] private GameObject _finnalyPage;


    private void Update()
    {
        //Raycasting
       Vector3 pos = _camera.ScreenToWorldPoint(Input.mousePosition);

        pos.z = 0;

    }
    public void GoToMiniGamesMenu()
    {
        _miniGameManager.OpenGameManagerMenu();
        this.gameObject.SetActive(false);
    }
    #region FindPage
    [ContextMenu("Open find Page")]
    public void OpenFindPage()
    {
        CloseAllpages();
        RemoveAllButtonListeners();
        ResetChekpoints();
        _buttonBack.onClick.AddListener(() => _miniGameManager.OpenGameManagerMenu());
        _findGame.SetActive(true);
        _findMenu.SetActive(true);
        _chuvak.EnableChuvaka();
        _chuvak.ChangeText(dialogues.Text[0]);
        
    }
    public void ResetChekpoints()
    {
        foreach (var c in _checkPoints)
            c.Reset();
    }
    public void CheckForWin()
    {
       for(int i =0; i<_checkPoints.Count; i++)
        {
            if (!_checkPoints[i].IsChecked)
                return;              
        }
        OpenOhraPage();
    }
    
    
    #endregion
    #region OhraPage
    public void OpenOhraPage()
    {
        CloseAllpages();
        RemoveAllButtonListeners();
        _buttonBack.onClick.AddListener(() => OpenFindPage());
        _ohraButton.gameObject.SetActive(true);
        _chuvak.EnableChuvaka();
        _chuvak.ChangeText(dialogues.Text[1]);
    }
    #endregion
    #region DrawPAge
    public void OpenDrawPage()
    {
        CloseAllpages();
        RemoveAllButtonListeners();
        _buttonBack.onClick.AddListener(() => OpenOhraPage());
        _drawGame.SetActive(true);
        _chuvak.DiasableChuvaka();
        _chuvak.ChangeText(dialogues.Text[2]);

    }
    public void CheckAllFillers()
    {
        foreach(var f in _fillers)
        {
            if (!f.IsFilled)
                return;
        }
        foreach (var f in _fillers)
            f.Reset();
        OpenFinnalyPage();
    }
    #endregion
    #region Finnaly Page
    public void OpenFinnalyPage()
    {
        CloseAllpages();
        RemoveAllButtonListeners();
        _buttonBack.onClick.AddListener(() => OpenDrawPage());
        _finnalyPage.SetActive(true);
        _chuvak.EnableChuvaka();
        _chuvak.ChangeText(dialogues.Text[3]);
    }
    #endregion
    private void CloseAllpages()
    {
        _findGame.SetActive(false);
        _findMenu.SetActive(false);
        _drawGame.SetActive(false);
        _finnalyPage.SetActive(false);
        _ohraButton.gameObject.SetActive(false); 
    }
    private void RemoveAllButtonListeners()
    {
        _buttonBack.onClick.RemoveAllListeners();
    }

    private void OnEnable()
    {
        OpenFindPage();
    }
}
