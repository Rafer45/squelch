using UnityEngine;
using System.Collections;

public class ShopSounds : MonoBehaviour {

    [SerializeField] private AudioClip booboo;
    [SerializeField] private AudioClip kaching;
    [SerializeField] private AudioClip click;
    // [SerializeField] private SettingsMenu sm;

    private AudioSource audioSource;
    private SettingsMenu sm;
    void Awake () {
        audioSource = GetComponent<AudioSource>();
        sm = GameObject.Find("_GM").GetComponent<SettingsMenu>();
    }
    
    // Update is called once per frame
    void PlaySound (string sound) {
        if (sm.sfx) {
            switch (sound) {
                case "booboo":
                    audioSource.PlayOneShot(booboo);
                    break;
                case "kaching":
                    audioSource.PlayOneShot(kaching);
                    break;
                case "click":
                    audioSource.PlayOneShot(click);
                    break;
                default:
                    // Debug.Log("EEEEEE");
                    break;    
            }
        }
    }
}
