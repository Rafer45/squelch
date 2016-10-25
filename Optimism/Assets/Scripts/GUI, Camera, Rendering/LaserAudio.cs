using UnityEngine;
using System.Collections;

public class LaserAudio : MonoBehaviour {

    private AudioSource audioSource;
    private Transform gm;
    private SettingsMenu sm;
    void Awake () {
        audioSource = GetComponent<AudioSource>();
        sm = GameObject.Find("_GM").GetComponent<SettingsMenu>();
    }
    
    public void Fire () {
        if (sm.sfx) {
            audioSource.Play();
        }
    }
}
