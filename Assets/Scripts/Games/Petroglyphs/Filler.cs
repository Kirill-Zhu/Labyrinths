using System.Collections;
using UnityEngine;


public class Filler : MonoBehaviour
{
    public bool IsFilled { get { return _isFilled; } }

    [SerializeField] private SpriteRenderer _srpite;
    [SerializeField] private bool _isFilled = false;
    private Coroutine _coroutine;
    
    [SerializeField] private PetroglyphsGameController _petroglyphsGameController;

    private void Awake()
    {
        _srpite = transform.GetChild(0).GetComponent<SpriteRenderer>();
       
    }


    public void FillImage()
    {
        Debug.Log("Fill Image");
        _coroutine = StartCoroutine(FillImage(Constants.PetroglyphFilltime));
    }
    private IEnumerator FillImage(float sec)
    {
        if(!_isFilled)
        {
            _isFilled = true;
            float iterations = 30;
            for (float i = 0; i < iterations; i++)
            {
                _srpite.color = new Color(_srpite.color.r, _srpite.color.g, _srpite.color.b, i/iterations);
                yield return new WaitForSeconds(sec);
            }
          
        }
        _petroglyphsGameController.CheckAllFillers();
    }
    public void Reset()
    {
        _isFilled = false;
        _srpite.color = new Color(_srpite.color.r, _srpite.color.g, _srpite.color.b, 0);
    }
  
}
