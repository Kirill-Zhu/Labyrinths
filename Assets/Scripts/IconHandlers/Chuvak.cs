using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading.Tasks;
using System.Threading;
public class Chuvak : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textMesh;

    
    [SerializeField] private Animator _animator;
    private bool _isEnabled;
    Coroutine _coroutine;
    private void Awake()
    {
        _isEnabled = true;
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _isEnabled = true;
        _animator = GetComponent<Animator>();
    }

    public void DiasableChuvaka()
    {
        if(_isEnabled)
        {
            _animator.SetTrigger("Disable");
            _isEnabled = false;
        }
       
        

    }
    public void EnableChuvaka()
    {
        if(!_isEnabled)
        {
            _animator.SetTrigger("Enable");
            _isEnabled = true;
        }
    }
    public void ChangeText(string dialogue)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
           
        _textMesh.text = null;
       
        _coroutine = StartCoroutine(Writing(dialogue, 0.02f));
          
    }
    private IEnumerator Writing(string dialogue,float sec)
    {
        for (int i = 0; i < dialogue.Length; i++)
        {
            _textMesh.text += dialogue[i];
            yield return new WaitForSeconds(sec);
        }
    }
   public static void Write()
    {

    }
}
