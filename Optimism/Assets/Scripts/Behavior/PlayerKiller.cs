using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerKiller : MonoBehaviour {

    public string target = "Player";
    public string nickname;
    public AudioClip murderSound;

    private GameObject gm;
    private GameObject kb;
    private SettingsMenu sm;
    private AudioSource audioSource;
    void Awake () {
        gm = GameObject.Find("_GM");
        kb = gm.transform.Find("ResetMenu/KilledBy").gameObject;
        sm = gm.GetComponent<SettingsMenu>();
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D (Collider2D other) {
        if (other.CompareTag(target)) {
            Murder(other.gameObject);
        }
    }

    void OnCollisionEnter2D (Collision2D other) {
        if (other.gameObject.CompareTag(target)) {
            Murder(other.gameObject);
        }
    }

    void Murder (GameObject victim) {
        if (sm.sfx) {
            audioSource.PlayOneShot(murderSound);
        }
        victim.SetActive(false);
        gm.SendMessage("GameOver", nickname);
        
        kb.SetActive(true);
        kb.SendMessage("OnMurder", nickname);
    }
}
