using UnityEngine;
using System.Collections;

public class MenuWallManager : MonoBehaviour {

    private Transform left;
    private Transform right;
    private Transform top;
    private Transform bot;

    private Transform leftNick;
    private Transform rightNick;

    [SerializeField] private Camera cam;
    [SerializeField] private Transform mZone;

    void Awake () {
        left  = transform.Find("Left");
        right = transform.Find("Right");
        top   = transform.Find("Top");
        bot   = transform.Find("Bot");

        leftNick  = left .Find("TopNick");
        rightNick = right.Find("TopNick");
    }

    void Start () {

        Vector3 xNudge = Vector3.right * (cam.ViewportToWorldPoint(Vector3.zero).x - (Vector3.right * -7.5F).x);

        left.position  += xNudge;
        right.position -= xNudge;

        bot.position   = Vector3.up * cam.ViewportToWorldPoint(Vector3.zero).y;
        top.position   = Vector3.up * cam.ViewportToWorldPoint(Vector3.one).y;

        leftNick.localScale  -= xNudge;
        rightNick.localScale -= xNudge;

        mZone.localScale -= xNudge * 2;

        Destroy(this);
    }
}
