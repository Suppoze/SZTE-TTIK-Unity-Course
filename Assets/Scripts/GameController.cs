using UnityEngine;
using System.Collections;
using System;
using Assets.Core;

public class GameController : MonoBehaviour {

    private const int LEFT_CLICK = 0;

    public BulletFireScript machinegun;
    public Animator overlayAnimator;

    private RespawnController respawnController;

    private void Awake() {
        respawnController = GetComponent<RespawnController>();
    }

    private void Start() {
        AchievementManager.instance.Unlock(Achievements.FIRST_GAME);
    }

    private void Update () {
        OnLeftClick();
        OnEscapePressed();
        OnPausePressed();
    }

    private void OnLeftClick() {
        if (Input.GetMouseButtonDown(LEFT_CLICK)) {
            machinegun.SetFiring(true);
        } else if (Input.GetMouseButtonUp(LEFT_CLICK)) {
            machinegun.SetFiring(false);
        }
    }

    private void OnEscapePressed() {
        if (Input.GetButtonDown("Cancel")) {
            Application.LoadLevel("Menu");
        }
    }

    private void OnPausePressed() {
        if (Input.GetButtonDown("Pause")) {
            UnityEditor.EditorApplication.isPaused = !UnityEditor.EditorApplication.isPaused;
        }
    }

    public void OnPlayerHurt() {
        overlayAnimator.SetTrigger("PlayerHurt");
    }

    public void  OnPlayerDead() {
        respawnController.ResetGame();
    }
}
