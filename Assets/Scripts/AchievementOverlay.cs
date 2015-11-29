using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AchievementOverlay : MonoBehaviour {

    public Text achievementTextField;

    private Animator animator;

    private void Awake() {
        animator = GetComponent<Animator>();
    }

	public void Popup(string unlockText) {
        achievementTextField.text = unlockText;
        animator.SetTrigger("Popup");
    }
}
