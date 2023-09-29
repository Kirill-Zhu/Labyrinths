using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using TMPro;
using System.Threading.Tasks;
public class NextButtonHandler : MonoBehaviour
{

    public GameObject LeftBound;

    [SerializeField] private TextMeshProUGUI _textMesh;
   

    [Inject]
    [SerializeField] private HomeButton _homeButton;
    [Inject]
    [SerializeField] private BackButton _backButton;

    private string _previousText;
    
    private Animator _animator;

    
    private void Start()
    {
        _previousText = _textMesh.text;
        _animator = GetComponent<Animator>();
    }
    private void Update()
    {
        OnButtonTextChanged();
    }
    private void OnButtonTextChanged()
    {
        if (_textMesh.text != _previousText)
        {
            _previousText = _textMesh.text;
            _homeButton.SetStandartPos();
            _backButton.SetStandartPos();
        }
    }

    public async void EnableNextButton()
    {
        if (_animator != null)
            _animator.SetTrigger("Enable");
        _textMesh.text = null;
        await Task.Delay(30);

        _homeButton.SetStandartPos();
        _backButton.SetStandartPos();
    }
    public void DisableNextButton()
    {
        if(_animator!=null)
        _animator.SetTrigger("Disable");
    }
    public async void ChangeText(string text)
    {
        _textMesh.text = null;
        
        
            for(int i=0; i<text.Length; i++)
            {

                _textMesh.text+= text[i];
                await Task.Delay(10);
                _homeButton.SetStandartPos();
                _backButton.SetStandartPos();
            }
        
            _textMesh.text = text;
            _previousText = _textMesh.text;
            
    }
        
}
