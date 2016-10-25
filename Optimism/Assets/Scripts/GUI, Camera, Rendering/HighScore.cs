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
        // shadow = GetComponent<Shadow>();

        // tColor = text.color;
        // sColor = shadow.effectColor;

        text.text = "High Score\n" + PlayerPrefs.GetInt("high_score", 0);
    }

    // void OnEnable () {
    //     // Debug.Log("OnEnable called");
    //     // DefaultColor();
    // }

    void OnHighScore (int score) {
        text.text = "High Score\n" + score;
        // ColorFlip();
    }

    // void ColorFlip () {
    //     Color temp = text.color;
    //     text.color = shadow.effectColor;
    //     shadow.effectColor = temp;
    // }

    // void DefaultColor () {
    //     text.color = tColor;
    //     shadow.effectColor = sColor;
    // }
}
