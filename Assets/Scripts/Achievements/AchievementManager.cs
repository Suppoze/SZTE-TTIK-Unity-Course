using UnityEngine;

namespace Assets.Scripts.Achievements
{
    public class AchievementManager : MonoBehaviour
    {
        public static AchievementManager Instance;

        public AchievementOverlay AchievementOverlay;

        private const string Killcount = "AchievementManager.KILLCOUNT";
        private const string Deathcount = "AchievementManager.DEATHCOUNT";

        private int _deathCount;
        private int _killCount;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            InitStat(Killcount, _killCount);
            InitStat(Deathcount, _deathCount);
        }

        private static void InitStat(string key, int stat)
        {
            if (PlayerPrefs.GetInt(key) > 0) return;
            PlayerPrefs.SetInt(key, 0);
        }

        public void Unlock(string key)
        {
            if (!IsLocked(key)) return;
            SetUnlocked(key);

            if (AchievementOverlay != null) AchievementOverlay.Popup(key);
        }

        public void AddKill()
        {
            _killCount++;
            if (_killCount == 1) Unlock(Core.Achievements.FirstKill);
            else if (_killCount == 8) Unlock(Core.Achievements.FirstLevelComplete);
        }

        public void AddDeath()
        {
            _deathCount++;
            if (_deathCount == 1) Unlock(Core.Achievements.FirstDeath);
        }

        public void ResetAchievments()
        {
            PlayerPrefs.DeleteAll();
        }


        public bool IsLocked(string key)
        {
            if (PlayerPrefs.GetInt(key) != 1) return true;
            return false;
        }

        private void SetUnlocked(string key)
        {
            PlayerPrefs.SetInt(key, 1);
        }
    }
}