using UnityEngine;
using System.Collections;

public class GlimmerBehaviour : MonoBehaviour {

    public float rotSpeed = 0.5F;
    public float resizeFreq = 4F;
    public float resizeAmp = 0.05F;

    void Update () {
        transform.Rotate(0,0,360*rotSpeed*Time.deltaTime);
        transform.localScale = Vector3.one * (0.5F + MathFun.TimeSine(resizeAmp, resizeFreq));
    }
}
