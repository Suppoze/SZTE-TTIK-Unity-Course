using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Assets.Core;

public class AchievementContainer : MonoBehaviour {

    public GameObject achievementRow;
    public Sprite lockedSprite;
    public Sprite unlockedSprite;

    private List<string> achievementList;
    private GridLayoutGroup gridLayout;

    private void Awake() {
        achievementList = Achievements.GetAchievements();
        gridLayout = GetComponent<GridLayoutGroup>();
    }

	void Start () {
        foreach (string achievement in achievementList) {
            GameObject obj = (GameObject) Instantiate(achievementRow, transform.position, transform.rotation);
            obj.GetComponentInChildren<Image>().sprite = AchievementManager.instance.IsLocked(achievement) ? lockedSprite : unlockedSprite;
            obj.GetComponentInChildren<Text>().text = achievement;
            obj.transform.SetParent(transform, false);
        }
	}
	
	void Update () {
	
	}
}
