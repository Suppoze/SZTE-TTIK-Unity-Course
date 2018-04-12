using Assets.Core;
using Assets.Scripts.Achievements;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public BulletFireScript Machinegun;
    public Animator OverlayAnimator;

    private const int LeftClick = 0;
    private RespawnController _respawnController;

    private void Awake()
    {
        _respawnController = GetComponent<RespawnController>();
    }

    private void Start()
    {
        AchievementManager.Instance.Unlock(Achievements.FirstGame);
    }

    private void Update()
    {
        OnLeftClick();
        OnEscapePressed();
        OnPausePressed();
    }

    private void OnLeftClick()
    {
        if (Input.GetMouseButtonDown(LeftClick)) Machinegun.SetFiring(true);
        else if (Input.GetMouseButtonUp(LeftClick)) Machinegun.SetFiring(false);
    }

    private static void OnEscapePressed()
    {
        if (Input.GetButtonDown("Cancel")) SceneManager.LoadScene("Menu");
    }

    private static void OnPausePressed()
    {
        if (Input.GetButtonDown("Pause"))
        {
            #if UNITY_EDITOR
                EditorApplication.isPaused = !EditorApplication.isPaused;
            #endif
        }
    }

    public void OnPlayerHurt()
    {
        OverlayAnimator.SetTrigger("PlayerHurt");
    }

    public void OnPlayerDead()
    {
        _respawnController.ResetGame();
    }
}