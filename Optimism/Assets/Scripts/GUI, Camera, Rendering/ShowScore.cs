using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShowScore : MonoBehaviour {

    public Transform player;
    private Text text;
    private int score = 0;

    private string str;
    private bool shouldUpdate = true;

    void Awake () {
        text = GetComponent<Text>();
    }

    void Update () {
        score = Mathf.Max(score, (int) Mathf.Floor(player.position.y));
        str = score.ToString();

        if (shouldUpdate)
            text.text = str;
    }

    void DebugStr(string inStr) {
        text.text = inStr;
        shouldUpdate = false;
    }

    void ZeroScore () {
        score = 0;
    }
}
