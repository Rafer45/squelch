using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UpdateButtonScript : MonoBehaviour {

    [SerializeField] private string prefix;
    private Text text;

    public void UpdateButton (bool b) {
        text = GetComponent<Text>();
        text.text = prefix + (b ? "\n<size=80>ON</size>" : "\n<size=80>OFF</size>");
    }
}
