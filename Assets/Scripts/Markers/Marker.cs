using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Markers
{
    [System.Serializable]
    public class ScreenPositionEvent : UnityEvent<Marker>
    {

    }

    [System.Serializable]
    public class Marker : MonoBehaviour
    {
        [SerializeField] private PlayerStats _player;

        public float MaxVisibleTime = 5;
        private float pingEndTime = 0;

        [SerializeField]
        private bool _seen = false;
        public bool Seen
        {
            get { return _seen; }
        }

        [SerializeField]
        private float _seenRange = 20f;
        [SerializeField]
        private float _seenMaxRange = -1f;

        [SerializeField]
        private Sprite _image;
        public Sprite Image
        {
            get { return _image; }
        }

        private bool _onScreen = false;
        public bool OnScreen
        {
            get { return _onScreen; }
        }
        Vector3 screenPos;
        Vector2 _onScreenPos;
        public Vector2 OnScreenPos
        {
            get { return _onScreenPos; }
        }
        private float _max;

        [SerializeField]
        private float _maxEdge = 0.05f;

        Camera camera;

        /// <summary>
        /// Screenspace position, seen or not
        /// </summary>
        public ScreenPositionEvent OnScreenPosition;
 

        // Use this for initialization
        void Start ()
        {
            camera = Camera.main;
            _player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
            PlayerPing ping = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerPing>();
            if (ping != null)
            {
                ping.OnPing.AddListener(StartVisibleAfterPing);
            }
        }
	
        // Update is called once per frame
        void Update ()
        {
            CameraPos();

            if (_onScreen && !_seen)
            {
                _seen = true;
            }

            //Debug.Log("Time: " + Time.time + " NextPingTime:" + pingEndTime);

            //Check if ping is still in effect
            if (Time.time <= pingEndTime)
            {
                _seen = true;
            }
            else
                _seen = false;


            if (_seenMaxRange > 0 && _seen)
            {
                if (Vector3.Distance(transform.position, _player.transform.position) > _seenMaxRange)
                {
                    _seen = false;
                }
            }

            if (OnScreenPosition != null)
            {
                OnScreenPosition.Invoke(this);
            }


        }

         
        void CameraPos () {
            screenPos = camera.WorldToViewportPoint(transform.position); //get viewport positions
 
            if(screenPos.x >= 0 && screenPos.x <= 1 && screenPos.y >= 0 && screenPos.y <= 1){
                //Debug.Log("already on screen, don't bother with the rest!");
                _onScreen = true;
                return;
            }
 
            _onScreenPos = new Vector2(screenPos.x-0.5f, screenPos.y-0.5f)*2; //2D version, new mapping
            _max = Mathf.Max(Mathf.Abs(_onScreenPos.x), Mathf.Abs(_onScreenPos.y)); //get largest offset
            _onScreenPos = (_onScreenPos/(_max*2))+new Vector2(0.5f, 0.5f); //undo mapping
            _onScreenPos = new Vector2(Mathf.Clamp(_onScreenPos.x, _maxEdge, 1 - _maxEdge),
                Mathf.Clamp(_onScreenPos.y, _maxEdge, 1 - _maxEdge));
            _onScreen = false;
            //Debug.Log(_onScreenPos);
        }

        public void StartVisibleAfterPing(Transform playerTransform)
        {
            pingEndTime = Time.time + MaxVisibleTime;

            Debug.Log("The Marker on "+name+" heard a ping.  Time: "+Time.time +" endPingTime: "+ pingEndTime);
        } 
    }
}
