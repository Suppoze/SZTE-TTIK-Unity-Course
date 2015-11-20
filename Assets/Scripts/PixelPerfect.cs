using UnityEngine;
using System.Collections;

public class PixelPerfect : MonoBehaviour {

    public int PPU;
    public int PPUScale;

    private void Awake() {
        GetComponent<Camera>().orthographicSize = (Screen.height / (PPU * PPUScale)) * 0.5f;
    }

}
