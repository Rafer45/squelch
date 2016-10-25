using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {

    [SerializeField] private GameObject menuGO;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject dad;
    [SerializeField] private GameObject dogs;
    [SerializeField] private GameObject cam;
    [SerializeField] private GameObject score;
    [SerializeField] private PauseGame pg;
    [SerializeField] private BackToMain btm;
    // private Object dzs;

    [SerializeField] public GameObject dzs;
    [SerializeField] private GameObject dzsPrefab;

    private Vector3 defaultDzsPos = new Vector3(-6F, -5F, 0F);

    public bool restart = false;
    // Use this for initialization
    void OnEnable () {
        // Debug.Log("restart: " + restart);
        if (!player.activeSelf) player.SetActive(true);
        player.SendMessage("OnStartGame", restart);

        menuGO.SendMessage("OnStartGame", restart, SendMessageOptions.DontRequireReceiver);

        cam.SendMessage("OnStartGame", restart);

        
        if (restart) {
            Destroy(dzs);
            dzs = (GameObject) Instantiate(dzsPrefab, defaultDzsPos, Quaternion.identity);
            // Debug.Log("dzs: " + dzs);
            btm.dzs = dzs;
        }

        dzs.BroadcastMessage("OnStartGame");

        if (!restart) {
            dad.SetActive(true);
        }
        dad.SendMessage("OnStartGame", restart);
        
        dad.transform.position = Vector3.zero + Vector3.down*50;

        if (!restart) {
            dogs.SetActive(true);
        }
        dogs.BroadcastMessage("OnStartGame");

        // if (!restart) {
        //     canvas.SetActive(true);
        // }

        if (restart) pg.enabled = false;
        pg.enabled = true;

        dogs.transform.position = Vector3.zero;

        if (Time.timeScale == 0) Time.timeScale = 1;

        score.SendMessage("ZeroScore");


        restart = true;
        this.enabled = false;
    }
}
