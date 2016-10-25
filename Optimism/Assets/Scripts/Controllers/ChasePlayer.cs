using UnityEngine;
using System.Collections;

public class ChasePlayer : MonoBehaviour {

    public float strength = 10f;

    private GameObject player;
    private Rigidbody2D rb;
    void Awake () {
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate () {
        Vector2 playerDist = (Vector2) (player.transform.position - transform.position);
        rb.AddForce(playerDist.normalized*strength, ForceMode2D.Force);
    }
}
