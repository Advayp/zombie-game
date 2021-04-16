using UnityEngine;

namespace Zombie.Player
{
    public class MoveCamera : MonoBehaviour
    {
        [SerializeField] private Transform head;

        private void Update()
        {
            transform.position = head.position;
        }
    }
}
