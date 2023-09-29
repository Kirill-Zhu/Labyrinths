using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Back : MonoBehaviour
{
    [SerializeField] private List<Sprite> _backList;
    [SerializeField] private Image _backImage;
    public void SetMainMenuBack()
    {
        _backImage.sprite = _backList[0];
    }
    public void SetLabirynthsMenuBack()
    {
        _backImage.sprite = _backList[0];
    }
    public void SetPageBack()
    {
        _backImage.sprite = _backList[2];
    }
}
