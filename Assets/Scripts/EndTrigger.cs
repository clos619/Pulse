using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTrigger : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Enter: " + other.name);
        if (other.tag == "Player")
        {
            Debug.Log("Player near tower!");
            SceneManager.LoadScene("EndScene");

        }

       

    }
}
