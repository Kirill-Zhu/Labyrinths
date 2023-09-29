using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UnityEngine.UI;

public class HomeButton : MonoBehaviour
{
    public float Spacing = 200;

    private Animator _animator;

    [Inject]
    [SerializeField] private NextButtonHandler _nextButton;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        SetStandartPos();
    }
    public void EnableHomeButton()
    {
        if (_animator != null)
            _animator.SetTrigger("Enable");
    }
    public void DisableHomeButton()
    {
        if (_animator != null)
            _animator.SetTrigger("Disable");
    }
    public void SetStandartPos()
    {
        GetComponent<RectTransform>().SetPositionAndRotation(_nextButton.LeftBound.GetComponent<RectTransform>().position + new Vector3(-Spacing,0), Quaternion.identity);
    }
    [ContextMenu("Set solo pos")]
    public async void SetSoloPos()
    {
        var rect = GetComponent<RectTransform>();
        Vector3 tmpPOs;
        rect.GetLocalPositionAndRotation(out tmpPOs, out Quaternion qwe);
        tmpPOs.x = 485;
        rect.SetLocalPositionAndRotation(tmpPOs, Quaternion.identity);
    }
}
