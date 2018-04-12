using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Achievements
{
    public class AchievementOverlay : MonoBehaviour
    {
        public Text AchievementTextField;

        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void Popup(string unlockText)
        {
            AchievementTextField.text = unlockText;
            _animator.SetTrigger("Popup");
        }
    }
}