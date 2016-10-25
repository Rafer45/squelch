using UnityEngine;
using System.Collections;

public class MenuGOBehaviour : MonoBehaviour {
    [SerializeField] private GameObject mz;

    void OnStartGame () {
        mz.SetActive(false);
    }

    void OnBackToMain () {
        mz.SetActive(true);
    }
}
