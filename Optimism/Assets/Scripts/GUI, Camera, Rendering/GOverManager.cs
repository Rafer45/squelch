using UnityEngine;
using System.Collections;

using UnityEngine.SceneManagement;

public class GOverManager : MonoBehaviour {

    [SerializeField] private GameObject resetMenu;
    [SerializeField] private GameObject dad;
    [SerializeField] private Transform player;
    private int score = 0;
    private int maxScore = 0;
    
    private PauseGame pg;
    private StartGame sg;
    private BackToMain btm;
    void Awake () {
        pg = GetComponent<PauseGame>();
        sg = GetComponent<StartGame>();
        btm = GetComponent<BackToMain>();
        // if (!PlayerPrefs.HasKey("high_score")) {
        //     PlayerPrefs.SetInt("high_score", 0);
        // }
        maxScore = PlayerPrefs.GetInt("high_score", 0);
    }

    void LateUpdate () {
        score = Mathf.Max(score, (int) player.position.y);
        // Debug.Log("score: " + score);
    }

    void GameOver () {

        resetMenu.SetActive(true);
        dad.SendMessage("OnGameOver");
        pg.enabled = false;

        if (maxScore < score) {
            // Debug.Log("OnHighScore called");
            maxScore = score;
            PlayerPrefs.SetInt("high_score", maxScore);
            resetMenu.BroadcastMessage("OnHighScore", maxScore);
        } else {
            ;
        }

        gameObject.SendMessage("SaveMoney", SendMessageOptions.DontRequireReceiver);
    }

    public void RestartButton () {
        BackToNormal();
        sg.enabled = true;
    }

    public void ShopButton () {
        BackToNormal();
        btm.shoppe = true;
        btm.enabled = true;
    }

    public void MainButton () {
        BackToNormal();
        btm.enabled = true;
    }

    void BackToNormal () {
        resetMenu.SetActive(false);
        Time.timeScale = 1F;
        pg.enabled = true;
        
    }
}
