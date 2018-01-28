using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VissionCollision : MonoBehaviour {

    private bool gameOver = false;
    private float countdown = 0f;
    [SerializeField]
    private AudioSource _audio;

    private GameObject player;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (gameOver)
        {

            Vector3 destinationDirection = (player.transform.position - this.gameObject.transform.position).normalized;
            this.gameObject.transform.rotation = Quaternion.LookRotation(destinationDirection);

            if (countdown < 1f)
            {
                countdown += Time.deltaTime;
            }
            else
            {
                GameOverManager.Instance.GameOver();
            }
        }
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            player = col.gameObject;
            GetComponent<MeshRenderer>().enabled = false;
            Vector3 destinationDirection = (player.transform.position - this.gameObject.transform.position).normalized;
            this.gameObject.transform.rotation = Quaternion.LookRotation(destinationDirection);

            this.gameObject.transform.Find("GeroBeam").gameObject.active = true;
            Monster monster = this.transform.parent.gameObject.GetComponent<Monster>();

            monster.Stop();

            gameOver = true;
            ScreenShake.Instance.Shake(0.8f, 2);
            _audio.Play();
            // Call death animation/game over stuff
            //GameOverManager.Instance.GameOver();
        }
    }

}
