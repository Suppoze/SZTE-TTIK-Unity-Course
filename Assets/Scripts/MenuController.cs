using Assets.Scripts.Achievements;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    private const int MainMenuConst = 0;
    private const int Achievements = 1;

    public Animator MainMenu;

    private ScreenManager _screenManager;

    private void Awake()
    {
        _screenManager = GetComponent<ScreenManager>();
    }

    private void Update()
    {
        OnEscapePressed();
    }

    private void OnEscapePressed()
    {
        if (Input.GetButtonDown("Cancel")) _screenManager.OpenPanel(MainMenu);
    }

    public void OnPlayClicked()
    {
        SceneManager.LoadScene("Level");
        Debug.Log("Clicked Play");
    }

    public void OnExitClicked()
    {
        Debug.Log("Clicked Exit");
        if (Application.isEditor)
        {
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#endif
            AchievementManager.Instance.ResetAchievments();
        }
        else
        {
            Application.Quit();
        }
    }
}