namespace Zombie.Player
{
    using UnityEngine;
    using Zombie.Core;
    public class MouseLook : MonoBehaviour, IEnableable
    {
        [SerializeField] private float mouseSensitivity;
        [SerializeField] private Transform player;

        private float _xRotation = 0f;
        private bool _isEnabled = true;

        public void Disable()
        {
            _isEnabled = false;
        }

        public void Enable()
        {
            _isEnabled = true;
        }

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        void Update()
        {
            if (!_isEnabled) return;

            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            Vector3 rot = transform.localRotation.eulerAngles;
            float desiredX = rot.y + mouseX;

            _xRotation -= mouseY;
            _xRotation = Mathf.Clamp(_xRotation, -90, 90);

            transform.rotation = Quaternion.Euler(_xRotation, desiredX, 0);
            player.transform.localRotation = Quaternion.Euler(0, desiredX, 0);

        }
    }

}
