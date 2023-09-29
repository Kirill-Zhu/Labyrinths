using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using System.Threading.Tasks;
public class MainMenuController : MonoBehaviour
{
   
    [SerializeField] private GameObject _labyrinths;
    [SerializeField] private GameObject _modernMenu;
    [SerializeField] private GameObject _pertoglyphs;

    [Inject]
    [SerializeField] private Chuvak _chuvak;
    [Inject]
    [SerializeField] private TopText _topText;
    [Inject]
    [SerializeField] private Back _back;
    [Inject]
    [SerializeField] private NextButtonHandler _nextBUtton;
    [Inject]
    [SerializeField] private BackButton _backButton;
    [Inject]
    [SerializeField] private HomeButton _homeButton;
    [TextArea(3,10)]
    public List<string> _dialogues;

    [SerializeField] private Animator _animator;

 
    public void Enable()
    {
        _animator.SetTrigger("Enable");
    }
    public async void Disable()
    {

        if (!gameObject.activeInHierarchy)
            return;

        _animator.SetTrigger("Disable");

        await Task.Delay(Constants.DelayForAnimations);
      

        gameObject.SetActive(false);
    }
   
}
