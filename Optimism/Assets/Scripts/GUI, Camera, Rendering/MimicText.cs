using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MimicText : MonoBehaviour {

    [SerializeField] private Text template;
    private string tempStr = "";

    private string prefix = "Score\n";

    private Text text;
    void Awake () {
        text = GetComponent<Text>();
    }
    
    void Update () {
        if (tempStr != template.text) {
            tempStr = template.text;
            text.text = prefix + tempStr;
        }
    }
}
