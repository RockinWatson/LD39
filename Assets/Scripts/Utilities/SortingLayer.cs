using UnityEngine;

namespace Assets.Scripts.Utilities
{
    public class SortingLayer : MonoBehaviour
    {
        private void Awake()
        {
            gameObject.GetComponent<MeshRenderer>().sortingLayerName = "UI";
            gameObject.GetComponent<MeshRenderer>().sortingOrder = 2;
        }
    }
}
