using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class ButtonPreview : MonoBehaviour {

    private int[] index = new int[2];
    private ShopKeeper sk;
    private ShopKeeper.Skin skin;

    [SerializeField] private ShowCoins sc;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject gm;

    private GameObject price;
    private Text text;
    
    private GameObject mannequin;
    private Image mqImg;

    private int n;

    void Awake () {
        int len = transform.name.Length;
        string strInd = transform.name.Substring(len-7);
        index[0] = strInd[1] - 48;
        index[1] = strInd[5] - 48;

        mannequin = transform.GetChild(0).gameObject;
        mqImg = mannequin.GetComponent<Image>();

        price = transform.GetChild(1).gameObject;
        text = price.GetComponent<Text>();

        sk = transform.parent.gameObject.GetComponent<ShopKeeper>();
        n = index[0]*5 + index[1];

        try   { SetPreview(sk.inventory[n]); }
        catch (System.IndexOutOfRangeException e) {
            mannequin.SetActive(false);
            price.SetActive(false);
        }
    }

    void Start () {
        UpdateSkin();
    }
    
    void SetPreview (ShopKeeper.Skin skin) {
        this.skin = skin;
        UpdateSkin();
    }

    void UpdateSkin () {
        if (mannequin.activeSelf) {
            mqImg.color = skin.unlocked ? Color.white : new Color(1F,1F,1F,0.4F);
            mqImg.sprite = skin.preview;
        }
        if (price.activeSelf && !skin.unlocked) {
            text.text = skin.cost.ToString();
        } else {
            price.SetActive(false);
        }
    }

    public void ToKeeper () {
        sk.SendMessage("SendSkin", n);
    }

    void TapToBuy (int i) {
        ShopKeeper.Skin skin = sk.inventory[i];
        if (sc.count >= skin.cost) {
            sc.SendMessage("CoinGet", -skin.cost);
            skin.unlocked = true;
            PlayerPrefs.SetInt(skin.address, 1);
            gm.SendMessage("SaveMoney");
            price.SetActive(false);
            player.SendMessage("WearSkin", skin);
            sk.SendMessage("PlaySound", "kaching");
        } else {
            sk.SendMessage("PlaySound", "booboo");
        }
    }
}
