using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField]
        private CharacterController _characterController;
        [SerializeField]
        private float _movementSpeed = 5f;

        // Use this for initialization
        void Start () {
		
        }
	
        // Update is called once per frame
        void Update () {
            var movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            if (movement.magnitude > 1)
            {
                movement.Normalize();
            }

            movement *= _movementSpeed;
            _characterController.SimpleMove(movement);
        }
    }
}
