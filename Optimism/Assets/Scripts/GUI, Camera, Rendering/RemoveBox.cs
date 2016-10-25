using UnityEngine;
using System.Collections;

public class RemoveBox : MonoBehaviour {

    public GameObject debugBox;
    public GameObject wallSeed;
    public GameObject player;
    public GameObject dad;
    public bool onStart;
    
    void Start () {
      if (onStart) {
          DoIt();
      }
    }

    // void Update () {
    //     if (Input.touches.Length > 1 || Input.GetKeyDown("space")) {
    //         DoIt();
    //     }
    // }

    void DoIt () {
        Destroy(debugBox);
        wallSeed.transform.position = player.transform.position - Vector3.up*-2f;
        wallSeed.SetActive(true);
        dad.SetActive(true);
        Destroy(this);
    }
}
