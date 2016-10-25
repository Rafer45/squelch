using UnityEngine;
using System.Collections;

public class LungerBehaviour : MonoBehaviour {

    // Lock on, tracking variables 
    private bool lockedOn = false;
    private bool tracking = false;
    private Vector3 lockOnPos;

    private float defaultThrowSpeed = 8f;
    public float throwSpeed = 8f;

    public AudioClip[] screeches = new AudioClip[4];
    private AudioClip screech;

    // Cached variables
    private GameObject player;
    private Animator myAnimator;
    private SettingsMenu sm;
    private AudioSource audioSource;
    void Awake () {
        player = GameObject.Find("Player");
        myAnimator = GetComponent<Animator>();
        sm = GameObject.Find("_GM").GetComponent<SettingsMenu>();
        audioSource = GetComponent<AudioSource>();
        screech = screeches[Random.Range(0,4)];
    }

    void Update () {
        if (tracking) {
            lockOnPos = player.transform.position;
        }

        // Track player
        if (lockedOn) {
            Vector3 diff = lockOnPos - transform.position;
            diff.Normalize();
            float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            transform.parent.rotation = Quaternion.Euler(0f, 0f, rot_z - 180);
        } else {
            transform.parent.Rotate(0f,0f,120f*Time.deltaTime);
            transform.localScale = Vector3.one*0.7f +
                                   Vector3.one*MathFun.TimeSine(0.1f, 1.5f, 0f);
        }
    }

    public void OnPlayerEnter () {
        if (sm.sfx) audioSource.PlayOneShot(screech);
        lockedOn = true;
        tracking = true;
        myAnimator.SetBool("lockedOn", true);
    }

    public void SetLockOnPos () {
        tracking = false;
    }

    public void Throw () {
        int escape = 0;
        while (transform.childCount > 1 && escape < 100) {
            Transform child = transform.GetChild(0);
            LungerBodyBehavior lbb = child.gameObject.GetComponent<LungerBodyBehavior>();
            if (lbb != null) {
                lbb.BeThrown((lockOnPos - transform.position).normalized*throwSpeed);
            }
            escape++;
        }
        Destroy(gameObject);
    }

    void ImportAss (float ass) {
        myAnimator.speed = 1 + (ass*0.3f);
        throwSpeed = defaultThrowSpeed * (1 + (ass*0.3f));
    }

}
