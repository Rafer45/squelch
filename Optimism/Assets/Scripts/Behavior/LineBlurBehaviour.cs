using UnityEngine;
using System.Collections;

public class LineBlurBehaviour : MonoBehaviour {

    private Vector3[] positions = new Vector3[2];
    private LineRenderer lr;
    private Color color;
    void Awake () {
        lr = GetComponent<LineRenderer>();
        color = transform.parent.gameObject
                        .GetComponent<SpriteRenderer>()
                          .color;

        positions[0] = Vector3.zero;
        positions[1] = Vector3.zero;
    }

    void Update () {
        if (positions[1].sqrMagnitude > 0.01F) {
            positions[1] = Vector3.Lerp(positions[1]
                                       ,Vector3.zero
                                       ,3.5F*Time.deltaTime);
        }
    }

    void LateUpdate () {
        transform.rotation = Quaternion.identity;
        lr.SetPositions(positions);
    }

    void OnFlick (Vector2 flick) {

        positions[1] = -flick*0.09F;
        Color c = color;
        Color t = color - new Color(0F,0F,0F,1F);
        lr.SetColors(c, t);
    }

    void SetBlurColor (Color col) {
        color = col;
    }
}
