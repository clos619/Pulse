using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts;

namespace Assets.Scripts
{
    

    public class PlayerStats : MonoBehaviour
    {

        // energyUI needs to know what the maximum energy is.
        [SerializeField] private const int MAX_ENERGY = 1500;
        public int MaxEnergy
        {
            get { return MAX_ENERGY; }
        }


        [SerializeField] private float _energy = MAX_ENERGY;
        public float Energy
        {
            get { return _energy; }
        }

        [SerializeField] private float _depleteSpeed = 50f;
        public float DepleteSpeed
        {
            get { return _depleteSpeed; }
        }

        [SerializeField] private float _moveDepleteSpeed = 50f;
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

            if (_energy <= 0)
            {
                if (GameOverManager.Instance != null)
                {
                    GameOverManager.Instance.GameOver();
                }
            }
        }

        public void UseMove(float inputScale)
        {
            _energy -= inputScale * Time.deltaTime * _moveDepleteSpeed;
        }

        public void Replenish(float amount)
        {
            
            _energy = _energy + amount;
            
            //screenShake.stop();
            //playerAudio.stop();
        }
    }
   
}
