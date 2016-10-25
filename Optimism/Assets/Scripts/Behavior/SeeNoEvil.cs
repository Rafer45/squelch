using UnityEngine;
using System.Collections;

public class SeeNoEvil : MonoBehaviour {

    // Cached variables
    private Renderer myRenderer;
    private bool visibilityChecker;
    void Awake () {
        myRenderer = GetComponent<Renderer>();
    }
    
    // Update is called once per frame
    void Update () {
        if (!myRenderer.isVisible) {
            Debug.Log(name + "destroyed by invisibility");
        }
    }
}
