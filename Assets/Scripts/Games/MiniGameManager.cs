using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class MiniGameManager : MonoBehaviour
{


    [SerializeField] private List<Sprite> _icons;
    [SerializeField] private List<GameObject> _games;
    [TextArea(1, 10)]
    [SerializeField] private string[] _buttonsTexts; 

    [SerializeField] private Image _image;
    [SerializeField] private Button _startButton;
    [SerializeField] private TextMeshProUGUI _startButtonText;
    public int _currentIconIndex=0;

    private CanvasGroup _canvasGroup;

    private void Start()
    {
        _currentIconIndex = 0;
        SetSprite(_currentIconIndex);
        _startButtonText.text = _buttonsTexts[_currentIconIndex];
        _startButton.onClick.AddListener(() => OpenGame());
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OpenGameManagerMenu()
    {
        _canvasGroup.alpha = 1;
        _canvasGroup.blocksRaycasts = true;
    }
    public void CloseGameManagerMenu()
    {
        _canvasGroup.alpha = 0;
        _canvasGroup.blocksRaycasts = false;
    }
    public void NextIcon()
    {
        for (int i = 0; i < _icons.Count; i++)
        {
            if (_image.sprite == _icons[i])
            {
                _currentIconIndex = i;
                break;
            }
        }

        try
        {
            _currentIconIndex++;
            SetSprite(_currentIconIndex);
        }
        catch
        {
            _currentIconIndex = 0;
            SetSprite(_currentIconIndex);
        }
        _startButtonText.text = _buttonsTexts[_currentIconIndex];
    }
    public void PreviousIcon()
    {
        for (int i = 0; i < _icons.Count; i++)
        {
            if (_image.sprite == _icons[i])
            {
                _currentIconIndex = i;
                break;
            }
        }

        try
        {
            _currentIconIndex--;
            SetSprite(_currentIconIndex);
        }
        catch
        {
            _currentIconIndex = _icons.Count-1;
            SetSprite(_icons.Count-1);
        }
        _startButtonText.text = _buttonsTexts[_currentIconIndex];
    }
    
    private void SetSprite(int index)
    {
        _image.sprite = _icons[index];
        _image.SetNativeSize();
    }

    public void OpenGame()
    {
        foreach (var g in _games)
            g.SetActive(false);

        _games[_currentIconIndex].SetActive(true);

        CloseGameManagerMenu();
    }
}
