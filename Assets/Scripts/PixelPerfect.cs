using UnityEngine;

public class PixelPerfect : MonoBehaviour
{
    public int Ppu;
    public int PpuScale;

    private void Awake()
    {
        GetComponent<Camera>().orthographicSize = Screen.height / (Ppu * PpuScale) * 0.5f;
    }
}