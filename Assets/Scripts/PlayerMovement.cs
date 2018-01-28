using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts
{
    [System.Serializable]
    public class MoveEvent : UnityEvent<float>
    {
    }

    [RequireComponent(typeof(CharacterController))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField]
        private CharacterController _characterController;
        [SerializeField]
        private float _movementSpeed = 5f;

        [SerializeField]
        private Transform _playerVisual;

        public Animator Animator;

        /// <summary>
        /// returns movement input from 0-1
        /// </summary>
        public MoveEvent OnMove;

        // Use this for initialization
        void Start () {
		
        }
	
        // Update is called once per frame
        void Update ()
        {
            var input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            var movement = input;
            if (movement.magnitude > 1)
            {
                movement.Normalize();
            }

            movement *= _movementSpeed;
            _characterController.SimpleMove(movement);

            if (OnMove != null)
            {
                OnMove.Invoke(input.magnitude);
            }

            Animator.SetFloat("Magnitude", input.magnitude);
            if (movement.magnitude > 0.02)
            {
                _playerVisual.forward =  transform.TransformDirection(input);
            }

        }
    }
}
