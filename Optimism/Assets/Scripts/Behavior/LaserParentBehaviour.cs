using UnityEngine;
using System.Collections;

public class LaserParentBehaviour : MonoBehaviour {

    private Animator kidAnim;
    private AudioSource kidAudio;
    void Awake () {
        GameObject kid = transform.GetChild(0).gameObject;
        kidAnim = kid.GetComponent<Animator>();
        kidAudio = kid.GetComponent<AudioSource>();
    }

    void ImportAss (float ass) {
        transform.localScale =
                    Vector3.one +
                    Vector3.up*(ass*1/2);
        kidAudio.pitch = 1.4F - ((ass/5F)*0.7F);
        kidAnim.Play("WallLaserShoot", -1, Random.Range(0f,ass/5f));
    }
}
