﻿using TMPro;
using UnityEngine;
using Zombie.Enemy;

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

        private void Update()
        {
            label.SetText($"Kills: {EnemyController.KillCount}");
        }
    }
}
