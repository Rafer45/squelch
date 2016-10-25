using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HighScore : MonoBehaviour {

    private Text text;
    private Shadow shadow;
    private Color tColor;
    private Color sColor;
    void Awake () {
        text = GetComponent<Text>();
        text.text = "High Score\n" + PlayerPrefs.GetInt("high_score", 0);
    }

    void OnHighScore (int score) {
        text.text = "High Score\n" + score;
    }
}
