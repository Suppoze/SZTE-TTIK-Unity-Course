using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    public ParallaxCamera ParallaxCamera;

    private readonly List<ParallaxLayer> _parallaxLayers = new List<ParallaxLayer>();

    private void Start()
    {
        if (ParallaxCamera == null)
            ParallaxCamera = Camera.main.GetComponent<ParallaxCamera>();
        if (ParallaxCamera != null)
            ParallaxCamera.OnCameraTranslate += Move;
        SetLayers();
    }

    private void SetLayers()
    {
        _parallaxLayers.Clear();
        for (var i = 0; i < transform.childCount; i++)
        {
            var layer = transform.GetChild(i).GetComponent<ParallaxLayer>();

            if (layer != null) _parallaxLayers.Add(layer);
        }
    }

    private void Move(Vector2 delta)
    {
        foreach (var layer in _parallaxLayers) layer.Move(delta);
    }

    public void AddNewTileToLayers(ParallaxLayer layer)
    {
        _parallaxLayers.Add(layer);
    }
}