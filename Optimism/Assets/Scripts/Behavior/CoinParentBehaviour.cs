using UnityEngine;
using System.Collections;

public class CoinParentBehaviour : MonoBehaviour {

    private bool wallLaser = false;
    private bool lunger    = false;
    public int value = 4;

    public Color bronze;
    public Color silver;
    public Color gold;

    private Transform kid;
    private SpriteRenderer kidRenderer;
    private SpriteRenderer glimRenderer;
    void Awake () {
        kid = transform.GetChild(0);
        kidRenderer  = kid.GetComponent<SpriteRenderer>();
        glimRenderer = kid.GetChild(0).GetComponent<SpriteRenderer>();
    }

    void OnWrapAround (Transform wrapper) {
        wallLaser = wrapper.Find("Obstacles/LaserParent" ).gameObject.activeSelf;
        lunger    = wrapper.Find("Obstacles/LungerParent").gameObject.activeSelf;

        kid.gameObject.SetActive(wallLaser || lunger);

        if (wallLaser ^ lunger) {
            value = wallLaser ? 1 : 2;
        } else {
            value = 4;
        }

        kid.localScale = Vector3.one * 1.5f;

        DrawCoin(value);
    }

    void DrawCoin (int val) {
        switch (val) {
            case 1:
                kidRenderer.color = bronze;
                break;
            case 2:
                kidRenderer.color = silver;
                break;
            case 4:
                kidRenderer.color = gold;
                break;
            default:
                Debug.Log("Invalid coin value");
                break;
        }
        glimRenderer.color = kidRenderer.color + ((Color) Vector4.one*0.15F);
    }
}
