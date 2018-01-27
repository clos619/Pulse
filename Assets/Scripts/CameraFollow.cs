using UnityEngine;

namespace Assets.Scripts
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField]
        private Transform _target;

        [SerializeField]
        private float _height = 10;
        [SerializeField]
        private float _moveSpeed = 2;

        // Use this for initialization
        void Start () {
		
        }
	
        // Update is called once per frame
        void Update ()
        {
            var targetPos = _target.position;
            targetPos.y += _height;
            transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * _moveSpeed);
        }
    }
}
