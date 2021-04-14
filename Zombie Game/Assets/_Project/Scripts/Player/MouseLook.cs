namespace Zombie.Player
{
    using UnityEngine;
    public class MouseLook : MonoBehaviour
    {
        [SerializeField] private float mouseSensitivity;
        [SerializeField] private Transform player;

        private float xRotation = 0f;

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        // Update is called once per frame
        void Update()
        {
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            Vector3 rot = transform.localRotation.eulerAngles;
            float desiredX = rot.y + mouseX;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90, 90);

            transform.rotation = Quaternion.Euler(xRotation, desiredX, 0);
            player.transform.localRotation = Quaternion.Euler(0, desiredX, 0);

        }
    }

}
