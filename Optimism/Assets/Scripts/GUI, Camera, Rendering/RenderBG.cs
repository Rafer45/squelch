using UnityEngine;
using System.Collections;

public class RenderBG : MonoBehaviour {

    [SerializeField] private Transform cam;
    private Renderer _renderer;

    // Chached variables
    public Vector3 offset = Vector3.zero;
    void Awake () {
        _renderer = GetComponent<Renderer>();
    }

    void Start () {
        _renderer.sortingLayerName = "BG";
    }

    void LateUpdate () {
        _renderer
          .material
            .mainTextureOffset = ((cam.position + offset)/transform.position.z);
    }
    void Offset (Vector2 offs) {
        offset += (Vector3) offs;
    }
}
