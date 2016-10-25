using UnityEngine;
using System.Collections;

public class PauseGame : MonoBehaviour {
    
    private bool pause;

    [SerializeField] private GameObject resetMenu;
    [SerializeField] private GameObject kb;

    void OnEnable () {
        pause = false;
        Time.timeScale = 1;
    }

    void Update () {
        if (Input.touchCount > 2 && Input.GetTouch(2).phase == TouchPhase.Began) {
            TogglePause();
        }
    }

    void TogglePause() {
        pause = !pause;
        Time.timeScale = pause ? 0 : 1;
        resetMenu.SetActive(pause);

        kb.SetActive(false);
    }
}
