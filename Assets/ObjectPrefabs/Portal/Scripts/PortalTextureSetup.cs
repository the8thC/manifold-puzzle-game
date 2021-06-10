using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTextureSetup : MonoBehaviour {
    public Camera Camera;
    public Shader shader;

    void Start() {
        if(Camera.targetTexture != null)
            Camera.targetTexture.Release();
        Camera.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);

        var cameraMaterial = new Material(shader);
        cameraMaterial.mainTexture = Camera.targetTexture;

        MeshRenderer meshRenderer = this.gameObject.GetComponent<MeshRenderer>();
        meshRenderer.material = cameraMaterial;
    }
}
