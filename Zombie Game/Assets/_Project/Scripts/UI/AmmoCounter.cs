using TMPro;
using UnityEngine;
using Zombie.Core;


namespace Zombie.UI
{
    public class AmmoCounter : MonoBehaviour, IAmmoCounter
    {
        [SerializeField] private int ammoStartCount;
        [SerializeField] private TMP_Text ammoLabel;


        public int AmmoCount { get; set; }

        private void Start()
        {
            AmmoCount = ammoStartCount;
        }

        private void Update()
        {
            UpdateText();
        }

        public void UpdateText()
        {
            ammoLabel.SetText($"Ammo {AmmoCount:00}");
        }
    }
}