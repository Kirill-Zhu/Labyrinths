using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using System.Threading.Tasks;
using UnityEngine.UI;

public class PageManager : MonoBehaviour
{

    [SerializeField] private CanvasRenderer _allPagesCanvasRenderer;

    [SerializeField] private Dialogue _factDialogues = new Dialogue();
    [SerializeField] private Dialogue _factTopText = new Dialogue();

    [Inject]
    private Chuvak _chuvak;
    [Inject]
    private TopText _topText;
    [Inject]
    private Back _back;
    [Inject]
    private NextButtonHandler _nextBUtton;
    [Inject]
    private BackButton _backButton;
    [Inject]
    private HomeButton _homeButton;
    [Inject]
    private MainMenuController _mainMenuController;
    [Inject]
    private LabirynthsMenuController _labirynthsMenuController;
    [Inject]
    private ModernSearchingsController _modernSearchingsController;
    [Inject]
    private PetroglyphsMenuController _petroglyphsMenuController;

    private Button _buttonNext;
    private Button _buttonBack;
    private Button _buttonHome;
    private void Awake()
    {
        _buttonNext = _nextBUtton.GetComponent<Button>();
        _buttonBack = _backButton.GetComponent<Button>();
        _buttonHome = _homeButton.GetComponent<Button>();
    }
    private void Update()
    {
      
    }


    #region Pages
    [ContextMenu("Open main menu")]
    public void OpenMainMenu()
    {
        _labirynthsMenuController.CloseAllPages();
        _mainMenuController.gameObject.SetActive(true);
        _mainMenuController.Enable();
        DisableChuvaka();
        DisableBackButton();
        DisableHomeButton();
        DisableNextButton();
        _back.SetMainMenuBack();

        _buttonHome.onClick.RemoveAllListeners();
        _buttonHome.onClick.AddListener(() => OpenMainMenu());

        _topText.ChangeText("");
    }
    #region Facts Pages
    public async void OpenLabirynthsMenu()
    {
        _mainMenuController.Disable();

        await Task.Delay(Constants.DelayForAnimations);

        _labirynthsMenuController.gameObject.SetActive(true);
        _labirynthsMenuController.OpenLabyrithsMenu();
        DisableChuvaka();
        DisableBackButton();
        DisableHomeButton();
        DisableNextButton();

        _topText.ChangeText(null);
        _back.SetLabirynthsMenuBack();
    }

    public async void OpenFactsFromMenu()
    {
        _labirynthsMenuController.CloseLabirynthsMenu();
        EnableChuvaka();
        EnableBackButton();
        EnableHomeButton();
        EnableNextButton();
        OpenFactsPage1();

        _topText.ChangeText(null);
        _back.SetPageBack();
    }
    public async void OpenFactsPage1()
    {
        

        //buttons
        _buttonNext.onClick.RemoveAllListeners();
        _buttonBack.onClick.RemoveAllListeners();
       

        await Task.Delay(Constants.DelayForAnimations);
       
        _buttonNext.onClick.AddListener(() => OpenFactsPage2());
        _nextBUtton.ChangeText("Далее");


        _buttonBack.onClick.AddListener(() => _labirynthsMenuController.CloseAllPages());
        _buttonBack.onClick.AddListener(() => OpenLabirynthsMenu());
        _labirynthsMenuController.OpenFacts(0);
       
      
        await Task.Delay(600);
        ChangeDialogueText(_factDialogues.Text[0]);
        _topText.ChangeText(_factTopText.Text[0]);
        _back.SetPageBack();
    }
   
    public async void OpenFactsPage2()
    {
 
        //buttons
        _buttonNext.onClick.RemoveAllListeners();      
        _buttonBack.onClick.RemoveAllListeners();
       

        _labirynthsMenuController.OpenFacts(1);

        await Task.Delay(Constants.DelayForAnimations);

        _buttonNext.onClick.AddListener(() => OpenFactsPage3());
        _nextBUtton.ChangeText("Далее");

        _buttonBack.onClick.AddListener(() => OpenFactsPage1());

        ChangeDialogueText(_factDialogues.Text[1]);
        _topText.ChangeText(_factTopText.Text[1]);
    }

    public async void OpenFactsPage3()
    {
      

        //buttons
        _buttonNext.onClick.RemoveAllListeners();       
        _buttonBack.onClick.RemoveAllListeners();
        

        _labirynthsMenuController.OpenFacts(2);

        await Task.Delay(Constants.DelayForAnimations);

        _buttonNext.onClick.AddListener(() => OpenFactsPage4());
        _nextBUtton.ChangeText("Далее");

        _buttonBack.onClick.AddListener(() => OpenFactsPage2());


        ChangeDialogueText(_factDialogues.Text[2]);
        _topText.ChangeText(_factTopText.Text[2]);
    }
    public async void OpenFactsPage4()
    {
        
        //buttons
        _buttonNext.onClick.RemoveAllListeners();
        _buttonBack.onClick.RemoveAllListeners();


        _labirynthsMenuController.OpenFacts(3);

        await Task.Delay(Constants.DelayForAnimations);

        _buttonNext.onClick.AddListener(() => OpenFactsPage5());
        _nextBUtton.ChangeText("Далее");

        _buttonBack.onClick.AddListener(() => OpenFactsPage3());


        ChangeDialogueText(_factDialogues.Text[3]);
        _topText.ChangeText(_factTopText.Text[3]);
    }
    public async void OpenFactsPage5()
    {
       
        //buttons
        _buttonNext.onClick.RemoveAllListeners();
        _buttonBack.onClick.RemoveAllListeners();


        _labirynthsMenuController.OpenFacts(4);

        await Task.Delay(Constants.DelayForAnimations);

        _buttonNext.onClick.AddListener(() => OpenKindsOfLabirynths());
        _nextBUtton.ChangeText("Виды лабиринтов");

        _buttonBack.onClick.AddListener(() => OpenFactsPage4());


        ChangeDialogueText(_factDialogues.Text[4]);
        _topText.ChangeText(_factTopText.Text[4]);
    }
    #endregion
    #region KindsPages
    public async void OpenKindsFromMenu()
    {
        _labirynthsMenuController.CloseLabirynthsMenu();
        EnableChuvaka();
        EnableBackButton();
        EnableHomeButton();
        EnableNextButton();

       

        await Task.Delay(Constants.DelayForAnimations);

        OpenKindsOfLabirynths();
    }
    public async void OpenKindsOfLabirynths()
    {

        
        //buttons 
        _buttonNext.onClick.RemoveAllListeners();
        _buttonBack.onClick.RemoveAllListeners();
        

        _labirynthsMenuController.OpenKindsPage();

        await Task.Delay(Constants.DelayForAnimations);

        _buttonNext.onClick.AddListener(() => OpenKolksyiPage());
        _nextBUtton.ChangeText("лабиринты кольсокго полуострова");
        
        _buttonBack.onClick.AddListener(() => OpenFactsPage5());


        ChangeDialogueText("Лабиринты бывают разных форм. Посмотри!");
        _topText.ChangeText("Виды лабиринтов");
        _back.SetPageBack();
    }

    #endregion
    #region KolsyiPage
    public async void OpenKolskyiFeomMenu()
    {
        _labirynthsMenuController.CloseLabirynthsMenu();

        await Task.Delay(Constants.DelayForAnimations);
        OpenKolksyiPage();
    }
   
    public async void OpenKolksyiPage()
    {
        _mainMenuController.Disable();

        DisableChuvaka();
        DisableBackButton();
        DisableNextButton();
        DisableHomeButton();

        _buttonNext.onClick.RemoveAllListeners();
        _buttonBack.onClick.RemoveAllListeners();

        _labirynthsMenuController.OpenKolsiyPage();

        await Task.Delay(Constants.DelayForAnimations);
       
        _homeButton.SetSoloPos();
        _homeButton.EnableHomeButton();
        

        _topText.ChangeText("Лабиринты Кольского полуострова");
        _back.SetPageBack();
    }
    #endregion
    #region Petroglyphs
    public async void OpenPetroglyphsPage()
    {
        _mainMenuController.Disable();

        DisableChuvaka();
        DisableBackButton();
        DisableNextButton();
        DisableHomeButton();
        _topText.ChangeText(null);

        await Task.Delay(Constants.DelayForAnimations);

        _homeButton.EnableHomeButton();
        _homeButton.SetSoloPos();
        _buttonHome.onClick.RemoveAllListeners();
        _buttonHome.onClick.AddListener(() => _petroglyphsMenuController.GoToManiMenu());   

        _petroglyphsMenuController.OpenPetroglyphs();
    }
    #endregion
    #region ModernSearchings
    public async void OpenModernSearchingsMenu()
    {
        _mainMenuController.Disable();


        DisableChuvaka();
        DisableBackButton();
        DisableNextButton();
        DisableHomeButton();

        _topText.ChangeText("Современные исследования");

        await Task.Delay(Constants.DelayForAnimations);

        _modernSearchingsController.OpenMenu();
        EnableHomeButton();
        _buttonHome.onClick.RemoveAllListeners();
        _buttonHome.onClick.AddListener(()=>_modernSearchingsController.GoToMainMenu());
        _homeButton.SetSoloPos();
    }
    #endregion
    #endregion
    #region Icons
    //Chuvak
    public void ChangeDialogueText(string text)
    {
       _chuvak.ChangeText(text);
    }
    public void DisableChuvaka()
    {
        _chuvak.DiasableChuvaka();
    }
    public void EnableChuvaka()
    {
        _chuvak.EnableChuvaka();
    }
  //Next Button
    [ContextMenu("Enable")]
    public void EnableNextButton()
    {
        _nextBUtton.EnableNextButton();
    }
    [ContextMenu("Dis")]
    public void DisableNextButton()
    {
        _nextBUtton.DisableNextButton();
    }
    //Home Button
    public void EnableHomeButton()
    {
        _homeButton.EnableHomeButton();
    }
  
    public void DisableHomeButton()
    {
        _homeButton.DisableHomeButton();
    }
    //Back Button
    public void EnableBackButton()
    {
        _backButton.EnableBackButton();
    }
  
    public void DisableBackButton()
    {
        _backButton.DisableBackButton();
    }
    //Top Text
    public void SetTopTextInvisible()
    {
        _topText.GetComponent<CanvasGroup>().alpha = 0;
    }
    public void SetTopTextVisible()
    {
        _topText.GetComponent<CanvasGroup>().alpha = 1;
    }
    #endregion
}
