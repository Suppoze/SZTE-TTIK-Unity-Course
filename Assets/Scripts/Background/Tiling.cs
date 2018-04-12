using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Tiling : MonoBehaviour
{
    public ParallaxBackground ParallaxBackground;
    public bool HasALeftBuddy;
    public bool HasARightBuddy;
    public bool ReverseScale = false;
    public int OffsetX = 2;

    private const int Left = -1;
    private const int Right = 1;

    private Camera _mainCamera;
    private float _spriteWidth;

    private void Awake()
    {
        _mainCamera = Camera.main;
    }

    private void Start()
    {
        var spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteWidth = spriteRenderer.sprite.bounds.size.x;
    }

    private void Update()
    {
        if (HasALeftBuddy && HasARightBuddy) return;

        var camHorizontalExtend = _mainCamera.orthographicSize * Screen.width / Screen.height;
        var edgeVisiblePositionRight = transform.position.x + _spriteWidth / 2 - camHorizontalExtend;
        var edgeVisiblePositionLeft = transform.position.x - _spriteWidth / 2 + camHorizontalExtend;

        if (_mainCamera.transform.position.x >= edgeVisiblePositionRight - OffsetX && !HasARightBuddy)
        {
            MakeNewBuddy(Right);
            HasARightBuddy = true;
        }
        else if (_mainCamera.transform.position.x <= edgeVisiblePositionLeft + OffsetX && !HasALeftBuddy)
        {
            MakeNewBuddy(Left);
            HasALeftBuddy = true;
        }
    }

    private void MakeNewBuddy(int rightOrLeft)
    {
        var newPosition = new Vector3(transform.position.x + _spriteWidth * rightOrLeft, transform.position.y,
            transform.position.z);
        var newBuddy = Instantiate(transform, newPosition, transform.rotation);

        if (ReverseScale)
            newBuddy.localScale = new Vector3(newBuddy.localScale.x * -1, newBuddy.localScale.y, newBuddy.localScale.z);

        newBuddy.parent = transform.parent;
        if (rightOrLeft > 0) newBuddy.GetComponent<Tiling>().HasALeftBuddy = true;
        else newBuddy.GetComponent<Tiling>().HasARightBuddy = true;
    }
}