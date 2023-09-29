using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace KultureChange
{
    [RequireComponent(typeof(Image))]
    [RequireComponent(typeof(Button))]
    public class ApplyButton : MonoBehaviour
    {
        public Button Button;

        [SerializeField] private List<Sprite> _icons;
        private Image _image;

        private void Awake()
        {
            _image = GetComponent<Image>();
            Button = GetComponent<Button>();
        }

        public void SetApplyIcon()
        {
            _image.sprite = _icons[0];
        }
        public void SetNextRoundIcon()
        {
            _image.sprite = _icons[1];
        }
        public void SetRetryRoundIcon()
        {
            _image.sprite = _icons[2];
        }
    }
}

