using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HighScoreReact : MonoBehaviour {

    private Text text;
    private Shadow shadow;
    private Color tColor;
    private Color sColor;
    void Awake () {
        text = GetComponent<Text>();
        shadow = GetComponent<Shadow>();

        tColor = text.color;
        sColor = shadow.effectColor;
    }
    void OnHighScore (int score) {
        ColorFlip();
    }

    void ColorFlip () {
        Color temp = text.color;
        text.color = shadow.effectColor;
        shadow.effectColor = temp;
    }

    void DefaultColor () {
        text.color = tColor;
        shadow.effectColor = sColor;
    }
}
