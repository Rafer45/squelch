using UnityEngine;
using System.Collections;

public class WrapAround : MonoBehaviour {

    // Position control
    public Vector3 offset = new Vector3(0f, 0f);
    public Vector3 cap = new Vector3(48f, 40f);

    private Vector3 HlfCap {
        get {
            return cap*0.5F;
        }
    }

    private Vector3 RelPos {
        get {
            return transform.position - HlfCap;
        }
    }
    
    // Charge control
    public Vector3 charge;
    private Vector3 prevCamPos;

    // Cached variables
    private Transform cam;
    void Awake () {
        cam = GameObject.FindWithTag("MainCamera").transform;
    }

    void Start () {
        prevCamPos = cam.position;
        charge = cam.position - transform.position + offset;
    }

    void LateUpdate () {
        Vector3 camMovement = cam.position - prevCamPos;
        charge += camMovement;

        if (charge.y >= HlfCap.y) {
            WrapTo(Vector3.up*cap.y );
        } else if (charge.y < -HlfCap.y) {
            WrapTo(Vector3.down*cap.y);
        }

        if (charge.x >= HlfCap.x) {
            WrapTo(Vector3.right*cap.x);
        } else if (charge.x < -HlfCap.x) {
            WrapTo(Vector3.left*cap.x);
        }
        prevCamPos = cam.position;
    }

    void WrapTo (Vector3 dir) {
        transform.position += dir;
        charge             -= dir;
        BroadcastMessage("OnWrapAround", transform, SendMessageOptions.DontRequireReceiver);
    }
}
