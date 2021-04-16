using UnityEngine;
using UnityEngine.UI;
using Zombie.Core;

namespace Zombie.UI
{
    [RequireComponent(typeof(Slider))]
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private GameObject player;

        private Slider slider;
        private IDamageable playerHealth;

        private void Awake()
        {
            playerHealth = player.GetComponent<IDamageable>();
            slider = GetComponent<Slider>();
        }

        private void Start()
        {
            slider.minValue = 0;
            slider.maxValue = playerHealth.maxHealth;
            slider.value = playerHealth.maxHealth;
        }


        private void Update()
        {
            slider.value = playerHealth.Health;
        }
    }

}
