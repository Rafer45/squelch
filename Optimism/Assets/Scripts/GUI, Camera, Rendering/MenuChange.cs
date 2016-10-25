using UnityEngine;
using System.Collections;

public class MenuChange : MonoBehaviour {

    [SerializeField] private GameObject gm;

    void OnTriggerExit2D (Collider2D other) {
        if (other.CompareTag("Player")) {
            gm.SendMessage("OnMenuChange", (Vector2) other.transform.position);
        }
    }
}
