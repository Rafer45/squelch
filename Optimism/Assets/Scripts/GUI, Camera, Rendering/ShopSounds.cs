using UnityEngine;
using System.Collections;

public class ShopSounds : MonoBehaviour {

    [SerializeField] private AudioClip booboo;
    [SerializeField] private AudioClip kaching;
    [SerializeField] private AudioClip click;

    private AudioSource audioSource;
    private SettingsMenu sm;
    void Awake () {
        audioSource = GetComponent<AudioSource>();
        sm = GameObject.Find("_GM").GetComponent<SettingsMenu>();
    }
    
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
                    break;    
            }
        }
    }
}
