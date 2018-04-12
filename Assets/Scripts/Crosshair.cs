using UnityEngine;

public class Crosshair : MonoBehaviour
{
    public static Crosshair Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        Cursor.visible = false;
        PositionCrosshair();
    }

    private void PositionCrosshair()
    {
        transform.position = (Vector2) Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}