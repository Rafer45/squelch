using UnityEngine;
using System.Collections;

public class MoneyManager : MonoBehaviour {

    [SerializeField] private ShowCoins sc;
    void SaveMoney () {
        PlayerPrefs.SetInt("coin_count", sc.count);
    }

}
