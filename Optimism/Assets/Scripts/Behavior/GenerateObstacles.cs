using UnityEngine;
using System.Collections;

public class GenerateObstacles : MonoBehaviour {

    // Obstacles
    public Transform obstacles;

    // Cached variables
    private GameObject player;
    void Awake () {
        player = GameObject.Find("Player");
    }

    public void OnWrapAround () {
        DeactivateObstacles();
        foreach (Transform obstacle in obstacles) {
            obstacle.gameObject
                .GetComponent<RollForMisfortune>()
                    .MaybeSpawn(Mathf.Max(player.transform.position.y, 0));
        }
    }
    
    void DeactivateObstacles () {
        foreach (Transform obstacle in obstacles) {
            obstacle.gameObject.SetActive(false);
        }
    }
}
