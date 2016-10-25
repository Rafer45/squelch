using UnityEngine;
using System.Collections;

public class SettingsMenu : MonoBehaviour {

    // private mPlayers;
    public bool music;
    public bool sfx;
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private UpdateButtonScript musicButton;

    // [SerializeField] private AudioSource[] sfxSources;
    [SerializeField] private UpdateButtonScript sfxButton;
    [SerializeField] private AudioSource miasma;
    
    void Awake () {
        music = IntToBool(PlayerPrefs.GetInt("settings_music", 1));
        sfx = IntToBool(PlayerPrefs.GetInt("settings_sfx", 1));
    }

    void Start () {
        Music(false);
        Sfx  (false);
    }

    // Should've used polymorphism here.
    public void Music (bool toggle=true) {
        if (toggle) {
            music = !music;
            PlayerPrefs.SetInt("settings_music", BoolToInt(music));
        }
        // Debug.Log("music: " + music);
        musicSource.mute = !music;
        musicButton.UpdateButton(music);
    }

    public void Sfx (bool toggle=true) {
        if (toggle) {
            sfx = !sfx;
            PlayerPrefs.SetInt("settings_sfx", BoolToInt(sfx));
        }
        miasma.mute = !sfx;
        sfxButton.UpdateButton(sfx);
    }

    bool IntToBool (int i) {
        return i == 1;
    }

    int BoolToInt (bool b) {
        return b ? 1 : 0;
    }
}
