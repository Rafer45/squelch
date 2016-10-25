using UnityEngine;
using System.Collections;

public class DangerZoneBehaviour : MonoBehaviour {

    void OnStartGame () {
        GetComponent<WrapAround>().enabled = true;
    }
}
