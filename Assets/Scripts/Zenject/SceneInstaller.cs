using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
public class SceneInstaller: MonoInstaller
{
    [Header("1-st Screen")]

    [SerializeField] private PageManager _pageManager;
    [SerializeField] private MainMenuController _mainMenuController;
    [SerializeField] private LabirynthsMenuController _labirynthsMenuController;
    [SerializeField] private ModernSearchingsController _modernSearchingsController;
    [SerializeField] private PetroglyphsMenuController _petroglyphsMenuController;

    [SerializeField] private NextButtonHandler _nextButton;
    [SerializeField] private HomeButton _homeButton;
    [SerializeField] private BackButton _backButton;
    [SerializeField] private TopText _topText;
    [SerializeField] private Back _back;
    [SerializeField] private Chuvak _Chuvak;


  

    public override void InstallBindings()
    {
        //1-st Screen
        Container.BindInstance<PageManager>(_pageManager);
        Container.BindInstance<MainMenuController>(_mainMenuController);
        Container.BindInstance<LabirynthsMenuController>(_labirynthsMenuController);
        Container.BindInstance<ModernSearchingsController>(_modernSearchingsController);
        Container.BindInstance<PetroglyphsMenuController>(_petroglyphsMenuController);

        Container.BindInstance<NextButtonHandler>(_nextButton);
        Container.BindInstance<HomeButton>(_homeButton);
        Container.BindInstance<BackButton>(_backButton);
        Container.BindInstance<TopText>(_topText);
        Container.BindInstance<Back>(_back);
        Container.BindInstance<Chuvak>(_Chuvak);


      
    }
}
