namespace Zombie.Other
{
    using UnityEngine;
    using Zombie.Core;
    public class Divider : MonoBehaviour
    {
        [SerializeField] private string playerName;

        private void OnTriggerEnter(Collider other)
        {

            var otherGO = other.gameObject;

            // This comparison will get called a lot
            // That is why I cache the result in a 
            // variable
            if (!(otherGO.name == playerName)) return;
            var damageable = otherGO.GetComponent<IDamageable>();
            if (damageable == null) return;

            // Kills the player no matter what
            damageable.TakeDamage(damageable.Health);
        }
    }

}
