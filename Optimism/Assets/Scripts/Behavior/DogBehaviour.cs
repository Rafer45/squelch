using UnityEngine;
using System.Collections;

public class DogBehaviour : MonoBehaviour {

    public Camera mainCam;
    public int firstDelay;
    public float chargeSpeed = 0.2F;
    private float ass = 0;

    [SerializeField] private AudioClip lungeSound;
    private Animator anim;
    private SettingsMenu sm;
    private AudioSource audioSource;
    void Awake () {
        anim = GetComponent<Animator>();
        sm = GameObject.Find("_GM").GetComponent<SettingsMenu>();
        audioSource = GetComponent<AudioSource>();
    }

    void LateUpdate () {
        transform.position = new Vector3(transform.position.x
                                        ,mainCam.transform.position.y
                                        ,0);
    }

    void Start () {
        anim.speed = 0;
        Invoke("AnimSpeedCharge", firstDelay/chargeSpeed);
    }

    void Lunge () {
        if (sm.sfx) audioSource.PlayOneShot(lungeSound);
        anim.speed = 1;
        anim.Play("DogLunge");
    }

    void WaitAndCharge () {
        anim.speed = 0;
        anim.Play("DogCharge");
        Invoke("AnimSpeedCharge", 2/chargeSpeed);
    }

    void AnimSpeedCharge () {
        anim.speed = chargeSpeed + ass*(0.8F);
    }

    void TootToot () {
        anim.speed = 1F;
        if (sm.sfx) audioSource.Play();
    }

    void ImportAss (float ass) {
        this.ass = ass;
    }

    void OnStartGame () {
        anim.speed = 0;
        ass = 0;
        anim.Play("DogCharge", -1, 0F);
        CancelInvoke();
        Invoke("AnimSpeedCharge", firstDelay/chargeSpeed);
    }
}
