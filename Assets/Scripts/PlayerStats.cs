using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts;

namespace Assets.Scripts
{
    

    public class PlayerStats : MonoBehaviour
    {
        
        
        [SerializeField] private float _energy = 1500;
        public float Energy
        {
            get { return _energy; }
        }

        [SerializeField] private float _depleteSpeed = 1f;
        public float DepleteSpeed
        {
            get { return _depleteSpeed; }
        }

        [SerializeField] private float _moveDepleteSpeed = 5f;
        public float MoveDepleteSpeed
        {
            get { return _moveDepleteSpeed; }
        }

        // Use this for initialization
        void Start () {
            
        }
	
        // Update is called once per frame
        void Update ()
        {
            
            _energy -= Time.deltaTime * _depleteSpeed;
        }

        public void UseMove(float inputScale)
        {
            _energy -= inputScale * Time.deltaTime * _moveDepleteSpeed;
        }

        void replenish()
        {
            
            _energy = _energy + 100;
            
            //screenShake.stop();
            //playerAudio.stop();
        }
    }
   
}
