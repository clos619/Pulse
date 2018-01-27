using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Markers
{
    public class MarkerUI : MonoBehaviour
    {
        public Image Image;

        public Marker Marker;

        private RectTransform _rectTransform; 

        // Use this for initialization
        void Start ()
        {
            _rectTransform = GetComponent<RectTransform>();
        }
	
        // Update is called once per frame
        void Update ()
        {
            _rectTransform.anchorMax = Marker.OnScreenPos;
            _rectTransform.anchorMin = Marker.OnScreenPos;
        }
    }
}
