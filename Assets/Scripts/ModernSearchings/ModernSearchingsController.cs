using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

public class ModernSearchingsController : MonoBehaviour
{
    [SerializeField] private List<GameObject> _pages;
    [SerializeField] private CanvasGroup _cavasGroup;

    [SerializeField] private Animator _animator;
    [Inject]
    private PageManager _pageManager;   
    public void OpenMenu()
    {
        foreach (var p in _pages)
            p.SetActive(false);

        _pages[0].SetActive(true);
        _animator.SetTrigger("Open");
    }
   public async void GoToMainMenu()
    {
        _animator.SetTrigger("Close");

        await Task.Delay(Constants.DelayForAnimations);
        foreach(var p in _pages)
        {
            if (p.activeInHierarchy)
                p.SetActive(false);
        }

        _pageManager.OpenMainMenu();
    }
    public async void OpenPage(int index)
    {
        _animator.SetTrigger("Close");

        await Task.Delay(Constants.DelayForAnimations);

        foreach (var p in _pages)
            p.SetActive(false);

        _pages[index].SetActive(true);
    }
}
