using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {
    
    public bool inGame = false;

    public float[] minMaxY = new float[2] { -27F, Mathf.Infinity };
    public Vector3 offset = new Vector3(0,4,-10);

    private GameObject player;
    void Awake () {
        player = GameObject.Find("Player");
    }

    void LateUpdate () {
        if (inGame) {
            GameFollow();
        } else {
            MenuFollow();
        }
    }

    void OnStartGame (bool restart) {
        inGame = true;
        if (restart) transform.position = player.transform.position;
    }

    void OnBackToMain () {
        inGame = false;
    }

    void GameFollow () {
        transform.position = new Vector3(transform.position.x
                                        ,player.transform.position.y + offset.y
                                        ,player.transform.position.z + offset.z);

        float targetX = player.transform.position.x;
        float posX = transform.position.x;

        transform.position = new Vector3(Mathf.SmoothStep(posX, targetX, Mathf.Min(Time.deltaTime*2*player.transform.position.y, 1F))
                                        ,transform.position.y
                                        ,transform.position.z);
    }

    void MenuFollow () {
        transform.position = new Vector3(0F
                                        ,Mathf.Clamp(player.transform.position.y, minMaxY[0], minMaxY[1])
                                        ,0F) +
                                        offset;
    }

    void SetMinY (float min=-27F) {
        minMaxY[0] = min;
    }

    void SetMaxY (float max=Mathf.Infinity) {
        minMaxY[1] = max;
    }
}
