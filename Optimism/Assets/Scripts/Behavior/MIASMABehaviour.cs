using UnityEngine;
using System.Collections;

public class MIASMABehaviour : MonoBehaviour {
    
    public Camera cam;
    public float defGap   = 15;
    public float defSpeed = 5;

    private float ass = 0;
    private float speed = 5;
    private bool gameOver = false;

    [SerializeField] private Transform player;
    [SerializeField] private GameObject dogDad;
    void Awake () {
        InvokeRepeating("SlowUpdate", 2, 2F);
    }

    void Update () {
        float gap = defGap - ass*5F;

        
        if (!gameOver) {
            transform.position = new Vector3 (player.position.x
                                             ,Mathf.Max(transform.position.y
                                                       ,player.position.y - gap)
                                             ,transform.position.z);


            if (transform.position.y > player.position.y + 1F) {
                transform.position = Vector3.zero - (Vector3.up*gap);
            }
        } else {
            speed = (player.position - transform.position).y < 20F
                  ? speed - Mathf.Abs(Time.deltaTime*5F * (1 + ass*4))
                  : 0;
        }

        transform.position += Vector3.up*speed*Time.deltaTime;
    }

    void SlowUpdate () {
        if (!gameOver) {
            ass = -MathFun.AsymptoteFn(player.position.y*0.2f, 131072
                                      ,160
                                      ,-5)/5;
            dogDad.BroadcastMessage("ImportAss", ass, SendMessageOptions.DontRequireReceiver);

            speed = defSpeed*(1+(ass*4));
        }
    }

    void OnGameOver () {
        gameOver = true;
    }

    void OnStartGame (bool restart) {
        gameOver = false;
        if (restart) SlowUpdate();
        transform.position = new Vector3 (player.position.x
                                         ,player.position.y - 30F
                                         ,transform.position.z);
    }
}
