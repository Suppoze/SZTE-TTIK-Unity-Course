using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Achievements
{
    public class AchievementContainer : MonoBehaviour
    {
        private List<string> _achievementList;

        public GameObject AchievementRow;
        public Sprite LockedSprite;
        public Sprite UnlockedSprite;

        private void Awake()
        {
            _achievementList = Core.Achievements.GetAchievements();
        }

        private void Start()
        {
            foreach (var achievement in _achievementList)
            {
                var obj = Instantiate(AchievementRow, transform.position, transform.rotation);
                obj.GetComponentInChildren<Image>().sprite = AchievementManager.Instance.IsLocked(achievement)
                    ? LockedSprite
                    : UnlockedSprite;
                obj.GetComponentInChildren<Text>().text = achievement;
                obj.transform.SetParent(transform, false);
            }
        }

    }
}