using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Markers
{
    public class MarkersUI : MonoBehaviour
    {
        public static MarkersUI Instance;

        private MarkerUI _markerPrefab;
        [SerializeField]
        private List<MarkerUI> _markers= new List<MarkerUI>();

        // Use this for initialization
        void Awake ()
        {
            Instance = this;
        }
	
        // Update is called once per frame
        void Update () {
		
        }


        public void OnMarkerUpdate(Marker marker)
        {
            MarkerUI markerUI = null;
            for (int cnt = 0; cnt < _markers.Count; cnt++)
            {
                if (_markers[cnt].Marker == marker)
                {
                    markerUI = _markers[cnt];
                }
            }

            if (markerUI == null)
            {
                if(marker.Seen == false)
                    return;

                markerUI = Instantiate(_markerPrefab, transform);
                markerUI.Marker = marker;
                _markers.Add(markerUI);

            }

        }
    }
}
