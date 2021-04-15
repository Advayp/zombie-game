namespace Zombie.UI
{
    using UnityEngine;
    using TMPro;
    using Zombie.Enemy;
    [RequireComponent(typeof(TMP_Text))]
    public class KillCounter : MonoBehaviour
    {
        public TMP_Text label;

        private void Awake()
        {
            label = GetComponent<TMP_Text>();
        }

        private void Update()
        {
            // There is probably a better way of doing this
            label.SetText($"Kills: {EnemyController.killCount}");
        }
    }
}
