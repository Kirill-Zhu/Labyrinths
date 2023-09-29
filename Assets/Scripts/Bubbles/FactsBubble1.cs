using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using TMPro;
public class FactsBubble1 : MonoBehaviour
{
    public bool ShowAtStart=false;
    [TextArea(3,10)]
    [SerializeField] private string _text;
    [SerializeField] private TextMeshProUGUI _textMesh;
    [SerializeField] private List<Sprite> _icons;
    [SerializeField] private GameObject _container;
    [SerializeField] private Image _iconImage;
    [SerializeField] private Button _button;
    [SerializeField] private bool _isRight;

    private void Awake()
    {
        _button.onClick.AddListener(()=>Openbubble());
        _textMesh.text = _text;
    }
    private void Start()
    {
        if (ShowAtStart)
            Openbubble();
    }
    public void Openbubble()
    {
        _iconImage.sprite = _icons[1];
        _button.onClick.RemoveAllListeners();
       if(_isRight)
        {
            _container.GetComponent<RectTransform>().pivot = new Vector2(0, 1);
            _container.GetComponent<RectTransform>().SetLocalPositionAndRotation(new Vector3(0, 0, 0), Quaternion.identity);
            _container.SetActive(true);
        }
        else
        {
            _container.GetComponent<RectTransform>().pivot = new Vector2(1, 1);
            _container.GetComponent<RectTransform>().SetLocalPositionAndRotation(new Vector3(-10, 0, 0), Quaternion.identity);
            _container.SetActive(true);
        }
        _button.onClick.AddListener(() => CloseBubble());
    }

    public void CloseBubble()
    {
        _iconImage.sprite = _icons[0];
        _button.onClick.RemoveAllListeners();
        _container.SetActive(false);
        _button.onClick.AddListener(() => Openbubble());
    }
}
