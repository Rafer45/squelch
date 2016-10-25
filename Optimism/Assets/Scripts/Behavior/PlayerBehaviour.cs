using UnityEngine;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour {

    private Rigidbody2D rb;
    void Awake () {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnStartGame (bool restart) {
        if (restart) {
            transform.position = Vector3.zero + Vector3.up*0.5F;
            rb.velocity = Vector3.zero;
        }
    }

    void OnBackToMain () {
        transform.position = Vector3.zero + Vector3.up*-34F;
        rb.velocity = Vector3.zero;
    }

    public void FaceWhereMoving (Vector2? dir=null) {
        dir = dir ?? rb.velocity;

        Vector2 vDir = (Vector2) dir;
        
        if (vDir != Vector2.zero) {
            vDir.Normalize();
            float rot_z = Mathf.Atan2(vDir.y, vDir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
        } else {
            transform.rotation = Quaternion.identity;
        }
    }

}
