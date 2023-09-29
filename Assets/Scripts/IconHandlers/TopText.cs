using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading.Tasks;

public class TopText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textMEsh;
    private string _previousText;
    public async void ChangeText(string text)
    {
        
        if(_previousText != text)
        {
            _textMEsh.text = null;
            if (text == null)
                return;
            for (int i = 0; i<text.Length; i++)
            {
                _textMEsh.text += text[i];
                await Task.Delay(10);
            }
            _previousText = _textMEsh.text;
        }
    }
}
