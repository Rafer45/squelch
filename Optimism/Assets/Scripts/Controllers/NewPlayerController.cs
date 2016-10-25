using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class NewPlayerController : MonoBehaviour {

    // Debug / tweaking variables
    public float debugSpeed = 100f;
    public float sensitivity = 80f;
    public float maxVel = 20f;
    public int maxJumps = 2;
    private float sqrMaxVel;

    // Physics variables
    public LayerMask wallLm;

    // Movement variables
    public int jumpsLeft = 0;
    private bool prevBool = true;
    private bool[] touchingWall = new bool[4] {false, false, false, false};
    [SerializeField] private Camera cam;

    // Sounds
    [SerializeField] private AudioClip[] jumpSounds = new AudioClip[2];
    [SerializeField] private AudioClip booboo;

    // Cached variables
    private CircleCollider2D cc;
    private Rigidbody2D rb;
    private GameObject blur;
    private float collHeight;
    private PlayerBehaviour pb;
    private AudioSource audioSource;
    private SettingsMenu sm;
    void Awake () {
        pb = GetComponent<PlayerBehaviour>();

        cc = GetComponent<CircleCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        collHeight = cc.radius;

        audioSource = GetComponent<AudioSource>();
        sm = GameObject.Find("_GM").GetComponent<SettingsMenu>();

        blur = transform.Find("Blur").gameObject;
        sqrMaxVel = maxVel*maxVel;
    }

    void Update () {

        if (Time.timeScale > 0F) {
            CheckTouchscreen();
        }

        CheckWallTouches();

        // DEBUG
        if (Input.GetKeyDown("space")) {
            FlickPlayer(new Vector2(100, 100));
        }

    }

    void CheckTouchscreen () {

        if (Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began) {
                prevBool = !EventSystem.current.IsPointerOverGameObject(touch.fingerId);
            }
            if (jumpsLeft > 0) {
                
                if (prevBool) {
                    Vector2 pScreenPos = cam.WorldToScreenPoint((Vector2) transform.position);
                    Vector2 flick = touch.position - pScreenPos;
    
                    if (touch.phase == TouchPhase.Ended) {
                        FlickPlayer(ClampFlick(flick));
                        prevBool = !EventSystem.current.IsPointerOverGameObject(touch.fingerId);
                    }
    
                    pb.FaceWhereMoving(flick);
                }
            } else {
                if (touch.phase == TouchPhase.Ended) audioSource.PlayOneShot(booboo);
            }

        } else {
            pb.FaceWhereMoving();
        }
    }

    Vector2 ClampFlick (Vector2 flick) {
        if (flick.sqrMagnitude > sqrMaxVel) {
            flick = Vector2.ClampMagnitude(flick, maxVel);
        }
        return flick;
    }

    void FlickPlayer (Vector2 flick) {

        if (jumpsLeft < 1) {
            audioSource.PlayOneShot(booboo);
            return;
        }

        GameObject eye;

        try   { eye = transform.Find("Eye" + jumpsLeft).gameObject; }
        catch { eye = null; }
        

        if (eye != null) {
            eye.GetComponent<Renderer>().enabled = false;
        }
        jumpsLeft--;
        if (sm.sfx) {
            if (jumpsLeft > 0) {
                audioSource.pitch = Random.Range(0.8F,0.9F);
                audioSource.volume = 0.4F;
                audioSource.PlayOneShot(jumpSounds[0]);
                audioSource.volume = 1F;
                audioSource.pitch = 1F;
            } else {
                audioSource.volume = 0.4F;
                audioSource.PlayOneShot(jumpSounds[1]);
                audioSource.volume = 1F;
            }
        }

        rb.velocity = flick;
        
        blur.SendMessage("OnFlick", flick);
    }

    void CheckWallTouches () {
        touchingWall[0] = WallCheck(Vector2.up   );

        touchingWall[1] = WallCheck(Vector2.left );

        touchingWall[2] = WallCheck(Vector2.down );

        touchingWall[3] = WallCheck(Vector2.right);

        if (Mathf.Abs(rb.velocity.x) < 1F && (touchingWall[1] || touchingWall[3]) ||
            touchingWall[2] || touchingWall[0]) {
            jumpsLeft = maxJumps;
            foreach (Transform eye in transform) {
              eye.gameObject.GetComponent<Renderer>().enabled = true;
            }
        }
    }

    bool WallCheck (Vector2 dir/*, Vector2 offs*/) {
        Vector2 min = Vector2.Reflect(dir, (new Vector2(1F, -1F)).normalized)*collHeight*0.9F;
        Vector2 max = Vector2.Reflect(dir, (new Vector2(1F,  1F)).normalized)*collHeight*0.9F + dir*0.1F;
        Vector2 tp = (Vector2) transform.position + dir*collHeight;

        Collider2D other =
            Physics2D
              .OverlapArea(tp + min
                          ,tp + max
                          ,wallLm.value);
        return other != null;
    }
}
