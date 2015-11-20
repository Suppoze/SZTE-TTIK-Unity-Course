using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]

public class Tiling : MonoBehaviour {

    private const int LEFT = -1;
    private const int RIGHT = 1;

    public ParallaxBackground parallaxBackground;

    public int offsetX = 2;

    public bool hasARightBuddy = false;
    public bool hasALeftBuddy = false;

    public bool reverseScale = false;

    private float spriteWidth = 0f;

    private Camera mainCamera;
    
    void Awake() {
        mainCamera = Camera.main;
    }

    void Start() {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteWidth = spriteRenderer.sprite.bounds.size.x;
    }

    void Update() {
        if (!hasALeftBuddy || !hasARightBuddy) {
            float camHorizontalExtend = mainCamera.orthographicSize * Screen.width / Screen.height;

            float edgeVisiblePositionRight = (transform.position.x + spriteWidth / 2) - camHorizontalExtend;
            float edgeVisiblePositionLeft = (transform.position.x - spriteWidth / 2) + camHorizontalExtend;

            if (mainCamera.transform.position.x >= edgeVisiblePositionRight - offsetX && !hasARightBuddy) {
                makeNewBuddy(RIGHT);
                hasARightBuddy = true;
            } else if (mainCamera.transform.position.x <= edgeVisiblePositionLeft + offsetX && !hasALeftBuddy) {
                makeNewBuddy(LEFT);
                hasALeftBuddy = true;
            }
        }
    }

    void makeNewBuddy(int rightOrLeft) {
        Vector3 newPosition = new Vector3(transform.position.x + spriteWidth * rightOrLeft, transform.position.y, transform.position.z);
        Transform newBuddy = Instantiate(transform, newPosition, transform.rotation) as Transform;

        if (reverseScale == true) {
            newBuddy.localScale = new Vector3(newBuddy.localScale.x * -1, newBuddy.localScale.y, newBuddy.localScale.z);
        }

        newBuddy.parent = transform.parent;
        if (rightOrLeft > 0) {
            newBuddy.GetComponent<Tiling>().hasALeftBuddy = true;
        } else {
            newBuddy.GetComponent<Tiling>().hasARightBuddy = true;
        }
    }
}
