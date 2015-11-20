using UnityEngine;

public class Crosshair : MonoBehaviour {

    public static Crosshair instance;

    private void Awake() {
        instance = this;
    }

    private void Update () {
        Cursor.visible = false;
        positionCrosshair();
    }

    private void positionCrosshair() {
        transform.position = (Vector2) Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

}
