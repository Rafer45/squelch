using UnityEngine;
using System.Collections;

public class DangerZonePlayerCheck : MonoBehaviour {

    private bool alreadyActivated = false;

    void OnTriggerEnter2D (Collider2D other) {
        if (other.CompareTag("Player") && !alreadyActivated) {
            BroadcastMessage("OnPlayerEnter", null, SendMessageOptions.DontRequireReceiver);
            alreadyActivated = true;
        }
    }

    void OnWrapAround () {
        alreadyActivated = false;
    }
}
