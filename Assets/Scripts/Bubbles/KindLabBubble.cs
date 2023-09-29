using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KindLabBubble : MonoBehaviour
{
    [SerializeField] private GameObject _sizeUp;
    [SerializeField] private Image _iconImage;
    private Image _currentImage;
    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _currentImage = GetComponent<Image>();
        _button.onClick.AddListener(() => EnableSizeUp());
    }
    public void EnableSizeUp()
    {
        _sizeUp.SetActive(true);
        _iconImage.sprite = _currentImage.sprite;

    }
    public void DisableSizeUp()
    {
        _sizeUp.SetActive(false);
    }
}
