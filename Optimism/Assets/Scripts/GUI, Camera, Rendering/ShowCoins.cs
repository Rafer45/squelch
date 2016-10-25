using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShowCoins : MonoBehaviour {

    public int count;
    private Text text;

    void Awake () {
        count = PlayerPrefs.GetInt("coin_count", 0);
        text = GetComponent<Text>();
        text.text = count.ToString();
    }
    
    // Update is called once per frame

    void CoinGet (int val) {
        text.text = (count += val).ToString();
    }
}
