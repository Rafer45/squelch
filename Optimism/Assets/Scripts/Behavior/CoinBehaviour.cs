using UnityEngine;
using System.Collections;

public class CoinBehaviour : MonoBehaviour {

    private GameObject counter;
    [SerializeField] private AudioClip pickupSound;

    private AudioSource audioSource;
    private SettingsMenu sm;
    void Awake () {
        sm = GameObject.Find("_GM").GetComponent<SettingsMenu>();
        counter = GameObject.Find("_GM/MainMenu");
    }

    void OnTriggerEnter2D (Collider2D other) {
        if (other.CompareTag("Player")) {
            if (audioSource == null) {
                audioSource = other.gameObject.GetComponent<AudioSource>();
            }
            if (sm.sfx) {
                audioSource.PlayOneShot(pickupSound);
            }

            gameObject.SetActive(false);
            counter.BroadcastMessage("CoinGet",
                transform.parent.gameObject
                    .GetComponent<CoinParentBehaviour>()
                        .value);

        }
    }
}
