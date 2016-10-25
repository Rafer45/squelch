using UnityEngine;
using System.Collections;

public class MathFun : MonoBehaviour {
    //  x + k
    // ------- + b
    // (x+t)^2
    public static float AsymptoteFn (float x, int k, int t, int b) {
        return
        (x + k) /
        (Mathf.Pow((x + t), 2))
        + b;
    }

    public static float TimeSine (float a=1, float b=1, float c=0) {
        return a * Mathf.Sin(b*Time.time + c);
    }

    public static float Mod (float a, float b) {
        return a - b * Mathf.Floor(a / b);
    }

    public static Color Inverse (Color color) {
        return new Color(1F-color.r, 1F-color.g, 1F-color.b);
    }
}
