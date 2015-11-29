using UnityEngine;
using System.Collections;
using System;
using Assets.Core;

public class AchievementManager : MonoBehaviour {

    private const string KILLCOUNT = "AchievementManager.KILLCOUNT";
    private const string DEATHCOUNT = "AchievementManager.DEATHCOUNT";

    private int killCount;
    private int deathCount;

    public AchievementOverlay achievementOverlay;

    public static AchievementManager instance;

    private void Awake() {
        instance = this;
    }

    private void Start() {
        InitStat(KILLCOUNT, killCount);
        InitStat(DEATHCOUNT, deathCount);
    }

    private void InitStat(string key, int stat) {
        if (!(PlayerPrefs.GetInt(key) > 0)) {
            stat = 0;
            PlayerPrefs.SetInt(key, 0);
        }
    }

    public void Unlock(string key) {
        if (IsLocked(key)) {
            SetUnlocked(key);
            if (achievementOverlay != null) {
                achievementOverlay.Popup(key);
            }
        }
    }

    public void AddKill() {
        killCount++;
        if (killCount == 1) {
            Unlock(Achievements.FIRST_KILL);
        } else if (killCount == 8) {
            Unlock(Achievements.FIRST_LEVEL_COMPLETE);
        }
    }

    public void AddDeath() {
        deathCount++;
        if (deathCount == 1) {
            Unlock(Achievements.FIRST_DEATH);
        }
    }

    public void ResetAchievments() {
        PlayerPrefs.DeleteAll();
    }

    public bool IsLocked(string key) {
        if (PlayerPrefs.GetInt(key) != 1) return true;
        else return false;
    }

    private void SetUnlocked(string key) {
        PlayerPrefs.SetInt(key, 1);
    }
}
