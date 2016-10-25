using UnityEngine;
using System.Collections;

using System;

public class MenuManager : MonoBehaviour {

    // private string menuStates[2] {
    //     get {
    //         Debug.Log("menuStates[2] set as " + menuStates[2]);
    //         return menuStates[2];
    //     }

    //     set {
    //         menuStates[2] = value;
    //     }
    // }
    private int index = 2;
    private string[] menuStates = new string[4];
    private string menuState = "SQUELCH";

    private float centerY = -10;

    [SerializeField] private Transform player;
    [SerializeField] private GameObject rightEdge;
    [SerializeField] private GameObject rightWall;
    [SerializeField] private GameObject rightBot;

    [SerializeField] private GameObject leftEdge;
    [SerializeField] private GameObject leftWall;
    [SerializeField] private GameObject leftBot;
    [SerializeField] private GameObject top;

    [SerializeField] private GameObject cam;

    [SerializeField] private TextMesh titleText;
    [SerializeField] private TextMesh leftText;
    [SerializeField] private TextMesh rightText;

    [SerializeField] private GameObject shopMenu;
    [SerializeField] private GameObject creditsMenu;
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private GameObject squelchMenu;

    // This is getting a bit thick - may be moved somewhere else.
    private StartGame startGame;
    void Awake () {
        menuStates[0] = "CREDITS";
        menuStates[1] = "SETTINGS";
        menuStates[2] = "SQUELCH";
        menuStates[3] = "SHOP";
        startGame = GetComponent<StartGame>();
    }

    void OnMenuChange (Vector2 pos) {
        if (pos.y > centerY) {
            TopChoice();
        } else {
            MovePlayer();
            if (pos.x < 0) {
                cam.transform.BroadcastMessage("Offset", Vector2.left * 15F);
                LeftChoice();
            } else if (0 < pos.x) {
                cam.transform.BroadcastMessage("Offset", Vector2.right * 15F);
                RightChoice();
            }
        }

    }

    void TopChoice () {
        StateChange("");
    }

    void LeftChoice () {
        StateChange(menuStates[--index]);
    }

    void RightChoice () {
        StateChange(menuStates[++index]);
    }

    void StateChange (string state) {
        menuState = state;

        Credits (state == menuStates[0]);
        Settings(state == menuStates[1]);
        Squelch (state == menuStates[2]);
        Shop    (state == menuStates[3]);

        titleText.text = menuState;
        try   { leftText.text  = menuStates[index - 1];
                LeftOverflow(false); }
        catch { leftText.text  = "";
                LeftOverflow(true); }

        try   { rightText.text = menuStates[index + 1];
                RightOverflow(false); }
        catch { rightText.text = "";
                RightOverflow(true); }

        if (state == "") {
            DoIt();
        }
    }

    void DoIt () {
        startGame.enabled = true;
    }

    void MovePlayer () {
        float nudge = rightEdge.transform.position.x;
        // Debug.Log("nudge: " + nudge);
        player.position = new Vector3(MathFun.Mod(player.position.x + nudge, (nudge*2)) - nudge
                                     ,player.position.y
                                     ,player.position.z);
    }

    void Credits (bool b) {
        // if (b) {
            // menuStates[0] = "CREDITS";
            // menuState = "CREDITS";
            // top.SetActive(b);
        // }
        // else {
            // menuStates[0] = "CREDITS";
        // }
        creditsMenu.SetActive(b);
        // if (b) cam.SendMessage("SetMaxY", -27F);
    }

    void Settings (bool b) {
        // if (b) {
        //     menuStates[1] = "SETTINGS\n\n";
        //     menuState = "SETTINGS\n\n";
        // }
        // else {
        //     menuStates[1] = "SETTINGS";
        // }
        settingsMenu.SetActive(b);
    }

    void Squelch (bool b) {
        // if (b) {
        //     menuStates[2] = "SHOP";
        //     top.SetActive(!b);
        // }
        top.SetActive(!b);
        squelchMenu.SetActive(b);
        if (b) {
            cam.SendMessage("SetMaxY", Mathf.Infinity);
        } else {
            cam.SendMessage("SetMaxY", -27F);
        }
    }

    void Shop (bool b) {
        // if (b) {
        //     menuStates[3] = "SHOP\n\n";
        //     menuState = "SHOP\n\n";
        //     top.SetActive(b);
        //     Debug.Log("menuStates[2] = \"SHOP\\n\\n\"");
        //     Debug.Log(menuStates[2]);
        // } else {
        //     menuStates[3] = "SHOP";
        // }
        shopMenu.SetActive(b);
    }

    void LeftOverflow (bool b) {
        leftEdge.SetActive(b) ;
        leftWall.SetActive(!b);
        leftBot .SetActive(!b);
    }

    void RightOverflow (bool b) {
        rightEdge.SetActive(b) ;
        rightWall.SetActive(!b);
        rightBot .SetActive(!b);
    }

    void OnBackToMain (bool shop=false) {
        MovePlayer();
        index = 3;
        menuStates[3] = "SHOP";

        LeftChoice();
        // I am very sorry about this system.
        if (shop) RightChoice();
        // menuState = "SQUELCH";
        // StateChange("SQUELCH");
    }
}
