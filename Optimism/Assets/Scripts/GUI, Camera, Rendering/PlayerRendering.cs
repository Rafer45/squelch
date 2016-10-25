using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerRendering : MonoBehaviour {

    [SerializeField] private ShopKeeper sk;
    [SerializeField] private Sprite squareSprite;
    [SerializeField] private Sprite circleSprite;
    [SerializeField] private Text skinName;

    private SpriteRenderer eyeSr1;
    private SpriteRenderer eyeSr2;

    private SpriteRenderer sr;
    private GameObject blur;
    private bool circle;

    void Awake () {
        sr = GetComponent<SpriteRenderer>();
        eyeSr1 = transform.GetChild(0).GetComponent<SpriteRenderer>();
        eyeSr2 = transform.GetChild(1).GetComponent<SpriteRenderer>();
        try {
            blur = transform.Find("Blur").gameObject;
        } catch { Debug.Log("noblur"); }
    }

    void Start () {
        WearSkin(sk.GetSkinByAddress(PlayerPrefs.GetString("player_skin", "squelch")));
    }

    void OnEnable () {
        StartCoroutine(CircleMode());
    }

    void WearSkin (ShopKeeper.Skin skin) {

        PlayerPrefs.SetString("player_skin", skin.address);
        skinName.text = skin.name;

        sr.color = skin.bodyColor;
        
        for (int i = 0; i < 3; i++) {
            transform.GetChild(i).localPosition = (Vector3) (new Vector2(i-0.5F, 0F)*0.5F + skin.eyeOffs);
            transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().color = skin.eyeColor;
        }

        for (int i = 0; i < 3; i++) {
            SpriteRenderer childSr = transform.GetChild(i+2).gameObject.GetComponent<SpriteRenderer>();

            ShopKeeper.Accessory acc;
            try {
                acc = skin.accessories[i];
            } catch {
                acc = new ShopKeeper.Accessory();
            }

            transform.GetChild(i+2).localPosition = acc.relPos;
            transform.GetChild(i+2).localScale = acc.scale;
            childSr.sprite = acc.sprite;
            childSr.color = acc.color;
        };

        if (skin.name == "GOD") {
            sr.sprite = circleSprite;
            eyeSr1.sprite = circleSprite;
            eyeSr2.sprite = circleSprite;
            circle = true;
            return;
        } else {
            sr.sprite = squareSprite;
            eyeSr2.sprite = squareSprite;
            eyeSr1.sprite = squareSprite;
            circle = false;
        }
        
        blur.SendMessage("SetBlurColor", skin.blurColor);
    }

    IEnumerator CircleMode () {
        Color col;
        // Color inv;
        float c = 0;
        SpriteRenderer flesh =
            transform.GetChild(2).GetComponent<SpriteRenderer>();
        while(true) {
            if (circle) {
                c += Time.deltaTime*0.05F;
                c %= 1F;
                col = Color.HSVToRGB(c,0.4F,1F);
                flesh.color = col;
                blur.SendMessage("SetBlurColor", col);
            }
            yield return null;
        }
    }
}
