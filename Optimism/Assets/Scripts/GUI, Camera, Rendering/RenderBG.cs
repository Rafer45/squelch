using UnityEngine;
using System.Collections;

public class RenderBG : MonoBehaviour {

    // public bool IsFollowing;
    // Chached variables
    public Vector3 offset = Vector3.zero;

    private Renderer _renderer;
    [SerializeField] private Transform cam;
    void Awake () {
        _renderer = GetComponent<Renderer>();
    }

    void Start () {
        _renderer.sortingLayerName = "BG";
    }

    void LateUpdate () {
        // if (IsFollowing) {
            _renderer
              .material
                .mainTextureOffset = ((cam.position + offset)/transform.position.z);
        // }
    }
    void Offset (Vector2 offs) {
        offset += (Vector3) offs;
        // Debug.Log("offset: " + offset);
    }
}
