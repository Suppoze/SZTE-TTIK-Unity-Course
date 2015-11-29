using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {

    private const int MAIN_MENU = 0;
    private const int ACHIEVEMENTS = 1;

    public Animator mainMenu;

    private ScreenManager screenManager;

    private void Awake() {
        screenManager = GetComponent<ScreenManager>();
    }

    private void Update() {
        OnEscapePressed();
    }

    private void OnEscapePressed() {
        if (Input.GetButtonDown("Cancel")) {
            screenManager.OpenPanel(mainMenu);
        }
    }

    public void OnPlayClicked() {
        Application.LoadLevel("Level");
        Debug.Log("Clicked Play");
    }

    public void OnExitClicked() {
        Debug.Log("Clicked Exit");
        if (Application.isEditor) {
            UnityEditor.EditorApplication.isPlaying = false;
            AchievementManager.instance.ResetAchievments();
        } else {
            Application.Quit();
        }
    }
}
