namespace Lab
{
    using UnityEngine;
    using UnityEngine.EventSystems;
    internal class LabChekpoint: MonoBehaviour
    {
        public bool IsPassed =false;

        
        private void OnMouseEnter()
        {
            Debug.Log("Chekpoint");
            IsPassed = true;
        }
        
    }

}

