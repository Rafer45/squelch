using UnityEngine;
using System.Collections;

public class BlurBehaviour : MonoBehaviour {

    private Quaternion dir = Quaternion.identity;    

    private SpriteRenderer myRenderer;
    private Color parentColor;
    void Awake () {
        myRenderer = GetComponent<SpriteRenderer>();
        parentColor = transform.parent.gameObject
                        .GetComponent<SpriteRenderer>()
                          .color;
    }

    void Update () {
        float yScale = transform.localScale.y;
        if (yScale > 0.1) {
            transform.localScale = new Vector3(1
                                         ,Mathf.Lerp(yScale, 0, 4*Time.deltaTime)
                                         ,1);
        }
    }

    void LateUpdate () {
        transform.rotation = dir;
    }

    void OnFlick (Vector2 flick) {
        var angle = Mathf.Atan2(flick.y,flick.x) * Mathf.Rad2Deg;
        dir = Quaternion.AngleAxis(angle + 90, Vector3.forward);

        float mag = flick.sqrMagnitude / 300f;
        transform.localScale = new Vector3 (1
                                      ,mag
                                      ,1);

        myRenderer.color = parentColor - new Color(0,0,0,0.5f);
    }

    void SetBlurColor (Color col) {
        parentColor = col;
    }
}
