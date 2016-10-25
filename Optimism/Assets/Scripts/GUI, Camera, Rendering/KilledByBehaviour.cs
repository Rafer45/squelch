using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class KilledByBehaviour : MonoBehaviour {

    private Text text;
    void Awake () {
        text = GetComponent<Text>();
    }
    
    void OnMurder (string name) {
        text.text = "Killed by\n" + name;
    }
}
