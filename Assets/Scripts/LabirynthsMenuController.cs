using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

public class LabirynthsMenuController : MonoBehaviour
{
    public GameObject _labirynhtMenu;
    public List<GameObject> _factsPages;
    public GameObject _kindsPage;
    public GameObject _KolsyiPage;

    [SerializeField] private GameObject _factsParentPage;
    private CanvasGroup _canvasGroup;
    [SerializeField] private Animator _animator;
    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
       
    }
    public void OpenLabyrithsMenu()
    {
        _labirynhtMenu.SetActive(true);
        _animator.SetTrigger("OpenMenu");
    }
    public async void CloseLabirynthsMenu()
    {
        if (!gameObject.activeInHierarchy)
            return;

            _animator.SetTrigger("CloseMenu");
        await Task.Delay(Constants.DelayForAnimations);
        _labirynhtMenu.SetActive(false);
       

    }
    public void CloseAllPages()
    {
        if (_kindsPage.activeInHierarchy)
            _kindsPage.SetActive(false);

        if (_KolsyiPage.activeInHierarchy)
            _KolsyiPage.SetActive(false);
        foreach (var f in _factsPages)
        {
            if (f.activeInHierarchy)
                f.SetActive(false);
        }
    }
  
    public async void OpenfactsFromMenu()
    {
        _animator.SetTrigger("CloseMenu");
        await Task.Delay(Constants.DelayForAnimations);

        _factsPages[0].SetActive(true);
        _canvasGroup.alpha = 0;

        float iterations = 30;
        for (float j = 1; j <= iterations; j++)
        {

            _canvasGroup.alpha = j / iterations;
            await Task.Delay(15);
        }
        
    }
    public async void OpenFacts(int index)
    {
       

        if (_kindsPage.activeInHierarchy)
            _kindsPage.SetActive(false);
         
        if (_KolsyiPage.activeInHierarchy)
            _KolsyiPage.SetActive(false);

        foreach (var f in _factsPages)
            f.SetActive(false);

        for (int i =0; i < _factsPages.Count; i++)
        {
        
            if (i == index)
            {
                _factsPages[i].SetActive(true);
                _canvasGroup.alpha = 0;

                float iterations = 30;
                for(float j = 1; j <= iterations; j++)
                {
                    
                    _canvasGroup.alpha =  j / iterations;
                    await Task.Delay(15);
                }
                continue;
            }           
        }
    }
    public async void OpenKindsPage()
    {
        foreach(var f in _factsPages)
        {
            if (f.activeInHierarchy)
                f.SetActive(false);
        }

        if (_KolsyiPage.activeInHierarchy)
            _KolsyiPage.SetActive(false);
       
        
       
        _kindsPage.SetActive(true);
    }
    public async void OpenKolsiyPage()
    {
        foreach (var f in _factsPages)
        {
            if (f.activeInHierarchy)
                f.SetActive(false);
        }

        if (_kindsPage.activeInHierarchy)
            _kindsPage.SetActive(false);

        _KolsyiPage.SetActive(true);
    }

}
