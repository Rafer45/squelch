using UnityEngine;
using System.Collections;

public class LungerBodyBehavior : MonoBehaviour {


    // Cached variables
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private Transform camTransform;
    void Awake () {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        coll.isTrigger = true;
        camTransform = GameObject.Find("MainCamera").transform;
    }

    void Update () {
        if (transform.parent == null) {
            Vector3 dist = camTransform.position - transform.position;
            if (dist.sqrMagnitude > 400) {
                Destroy(gameObject);
            }
        }
    }

    public void BeThrown (Vector3 dir) {
        coll.isTrigger = false;
        rb.velocity = dir;
        transform.parent = null;
    }
}
