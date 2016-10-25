using UnityEngine;
using System.Collections;

public class BackToMain : MonoBehaviour {


    [SerializeField] private GameObject menuGO;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject dad;
    [SerializeField] private GameObject dogs;
    [SerializeField] private GameObject cam;
    [SerializeField] private GameObject score;

    [SerializeField] private PauseGame pg;
    [SerializeField] private StartGame sg;
    // private Object dzs;

    [SerializeField] public GameObject dzs;
    [SerializeField] private GameObject dzsPrefab;

    public bool shoppe = false;

    private Vector3 defaultDzsPos = new Vector3(-6F, -5F, 0F);

    // Use this for initialization
    void OnEnable () {

        if (!player.activeSelf) player.SetActive(true);
        player.SendMessage("OnBackToMain");

        menuGO.SendMessage("OnBackToMain");

        cam.SendMessage("OnBackToMain");

        
        Destroy(dzs);
        dzs = (GameObject) Instantiate(dzsPrefab, defaultDzsPos, Quaternion.identity);
        
        dad.SetActive(false);
        dad.transform.position = Vector3.zero + Vector3.down*50;
        // dad.SendMessage("OnBackToMain", restart);
        

        dogs.SetActive(false);
        dogs.transform.position = Vector3.zero;

        // if (!restart) {
        //     canvas.SetActive(true);
        // }


        if (Time.timeScale == 0) Time.timeScale = 1;

        score.SendMessage("ZeroScore");

        pg.enabled = false;
        sg.restart = false;
        sg.dzs = dzs;

        gameObject.SendMessage("OnBackToMain", shoppe);
        shoppe = false;

        this.enabled = false;
    }

}
