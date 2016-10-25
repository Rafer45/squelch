using UnityEngine;
using System.Collections;

public class PauseGame : MonoBehaviour {
    
    private bool pause/* = false*/;

    // [SerializeField] private GameObject restart;
    // [SerializeField] private GameObject main;
    [SerializeField] private GameObject resetMenu;
    [SerializeField] private GameObject kb;

    void OnEnable () {
        pause = false;
        // Debug.Log("pause OnSetActive called");
        Time.timeScale = 1;
    }

    void Update () {
        if (Input.touchCount > 2 && Input.GetTouch(2).phase == TouchPhase.Began ||
           Input.GetKeyDown("p")) {
            TogglePause();
        }
    }

    void TogglePause() {
        pause = !pause;
        // Debug.Log("pause: " + pause);
        // if (pause) {
        //     ;
        // }
        Time.timeScale = pause ? 0 : 1;
        // overlay.transform.position = player.transform;
        // overlay.SetActive(pause);
        resetMenu.SetActive(pause);

        kb.SetActive(false);
        // restart.SetActive(pause);
        // main   .SetActive(pause);
    }
}
