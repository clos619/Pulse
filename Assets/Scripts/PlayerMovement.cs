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

        }
    }
}
