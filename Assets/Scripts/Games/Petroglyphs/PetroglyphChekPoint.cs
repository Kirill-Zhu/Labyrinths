using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PetroglyphChekPoint : MonoBehaviour, IPointerEnterHandler
{

   
    
    public bool IsChecked { get { return _isChecked; } }
   
    [SerializeField] private PetroglyphsGameController _petroglyphsGameController;
    [SerializeField] private bool _isChecked;
   
    private void Start()
    {
        _isChecked = false;
    }
    public void Reset()
    {
        _isChecked = false;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        _isChecked = true;
        _petroglyphsGameController.CheckForWin();
    }
}
