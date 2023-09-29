using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

public class PetroglyphsMenuController : MonoBehaviour
{
    [SerializeField] private GameObject _scroller;

    [Inject]
    private PageManager _pageManager;
    public void OpenPetroglyphs()
    {
        _scroller.SetActive(true);
    }
    public async void GoToManiMenu()
    {
        _scroller.SetActive(false);

        await Task.Delay(Constants.DelayForAnimations);

        _pageManager.OpenMainMenu();
    }
}
