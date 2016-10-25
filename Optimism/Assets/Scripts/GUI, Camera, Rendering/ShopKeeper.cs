using UnityEngine;
using System.Collections;

public class ShopKeeper : MonoBehaviour {

    [System.Serializable]
    public class Accessory {

        public Sprite  sprite;
        public Color   color ;
        public Vector2 relPos;
        public Vector2 scale ;

        public Accessory (Sprite sprite, Color color, Vector2 relPos, Vector2 scale) {
            this.sprite = sprite;
            this.color  = color;

            this.relPos = relPos;
            this.scale  = scale;
        }

        public Accessory () {
            this.sprite = null;
            this.color = Color.clear;

            this.relPos = Vector2.zero;
            this.scale  = Vector2.zero;
        }

    }

    [System.Serializable]
    public class Skin {
        public string name;
        public string address;
        public Color bodyColor;
        public Color blurColor;
        public Accessory[] accessories;
        public int cost;
        public Sprite preview;
        public Vector2 eyeOffs;
        public Color eyeColor;

        public bool unlocked = false;

        public Skin (string name
                    ,string address
                    ,Color bodyColor
                    ,Color blurColor
                    ,Accessory[] accessories
                    ,int cost
                    ,Sprite preview
                    ,Vector2 eyeOffs
                    ,Color eyeColor) {
            this.name = name;
            this.address = address;
            this.bodyColor = bodyColor;
            this.cost  = cost; 
            this.accessories = accessories;
            this.preview = preview;
            this.eyeOffs = eyeOffs;
            this.eyeColor = eyeColor;
        }
    }

    public Skin[] inventory = new Skin[2];
    
    public GameObject player;
    private GameObject[] shopButtons = new GameObject[10];
    void Awake () {
        foreach (Skin skin in inventory) {
            skin.unlocked = PlayerPrefs.GetInt(skin.address, 0) == 1;
        }
        for (int i = 0; i < 10; i++) {
            shopButtons[i] = transform.GetChild(i).gameObject;
        }
    }

    public void SendSkin (int i) {
        Skin skin;

        try {
            skin = inventory[i];
        } catch (System.IndexOutOfRangeException e) {
            return;
        }
        
        if (skin.unlocked) {
            player.SendMessage("WearSkin", inventory[i]);
            gameObject.SendMessage("PlaySound", "click");
        } else {
            shopButtons[i].SendMessage("TapToBuy", i);
            shopButtons[i].SendMessage("SetPreview", skin);
        }
    }

    public Skin GetSkinByAddress (string address) {
        foreach (Skin skin in inventory) {
            if (skin.address == address) {
                return skin;
            }
        }
        return inventory[0];
    }
}
