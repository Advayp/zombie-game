using TMPro;
using UnityEngine;
using Zombie.Core;

namespace Zombie.UI
{
    [RequireComponent(typeof(TMP_Text))]
    public class KillCounter : MonoBehaviour
    {
        public TMP_Text label;

        private void Awake()
        {
            label = GetComponent<TMP_Text>();
        }

        private void Start()
        {
            EnemyController.OnKill += UpdateLabel;
        }

        private void UpdateLabel(int newCount)
        {
            label.SetText($"Kills: {newCount}");
        }
    }
}
