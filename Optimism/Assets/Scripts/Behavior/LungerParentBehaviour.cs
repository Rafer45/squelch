using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LungerParentBehaviour : MonoBehaviour {

    void Update () {
        if (transform.childCount < 1) {
            Rebirth();
        }
    }

    public GameObject childPrefab;
    public void Rebirth () {
        gameObject.SetActive(false);
        GameObject kid =
          (GameObject) 
           GameObject.
           Instantiate(childPrefab, transform.position, Quaternion.identity);
        kid.transform.parent = gameObject.transform;
    }
}
