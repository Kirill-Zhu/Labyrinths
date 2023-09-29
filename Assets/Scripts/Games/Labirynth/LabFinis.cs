namespace Lab
{
    using UnityEngine;
    using UnityEngine.EventSystems;
    internal class LabFinis :MonoBehaviour
    {
        [SerializeField] private LabPlayerController _labPlayerController;

        private void OnMouseEnter()
        {
            _labPlayerController.Finish();
        }
    }
}