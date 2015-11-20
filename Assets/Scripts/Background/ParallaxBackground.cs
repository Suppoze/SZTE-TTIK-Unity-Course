using UnityEngine;
using System.Collections.Generic;

public class ParallaxBackground : MonoBehaviour {

    public ParallaxCamera parallaxCamera;

    private List<ParallaxLayer> parallaxLayers = new List<ParallaxLayer>();

    private void Start() {
        if (parallaxCamera == null)
            parallaxCamera = Camera.main.GetComponent<ParallaxCamera>();
        if (parallaxCamera != null)
            parallaxCamera.onCameraTranslate += Move;
        SetLayers();
    }

    private void SetLayers() {
        parallaxLayers.Clear();
        for (int i = 0; i < transform.childCount; i++) {
            ParallaxLayer layer = transform.GetChild(i).GetComponent<ParallaxLayer>();

            if (layer != null) {
                parallaxLayers.Add(layer);
            }
        }
    }

    private void Move(Vector2 delta) {
        foreach (ParallaxLayer layer in parallaxLayers) {
            layer.Move(delta);
        }
    }

    public void AddNewTileToLayers(ParallaxLayer layer) {
        parallaxLayers.Add(layer);
    }
}
