using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PingManager : MonoBehaviour
{
    public Canvas UiCanvas;
    public GameObject TowerIcon;
    Vector3 lastPlayerLocation;
    List<Transform> pingableLocations = new List<Transform>();

    // Use this for initialization
    void Start()
    {
        foreach (GameObject pingGO in GameObject.FindGameObjectsWithTag("Pingable"))
        {
            pingableLocations.Add(pingGO.transform);
        }


    }

    public void DrawTowerIcons()
    {
        foreach (Transform tower in pingableLocations)
        {
            //GameObject clone = Instantiate(TowerIcon, UICanvas, true)
        }
    }
}

