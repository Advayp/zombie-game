namespace Zombie.Game
{
    using UnityEngine;
    using UnityEngine.SceneManagement;
    using Zombie.Core;
    public class GameManage : MonoBehaviour
    {
        [SerializeField] private GameObject player;
        [SerializeField] private GameObject gameEndedUI;
        [SerializeField] private GameObject[] objectsToDisableOnDeath;


        private IDamageable damageable;

        private void Awake()
        {
            damageable = player.GetComponent<IDamageable>();
            objectsToDisableOnDeath = GameObject.FindGameObjectsWithTag("enableable");
        }

        private void Start()
        {
            damageable.Death += EndGame;
        }

        public void EndGame()
        {
            gameEndedUI.SetActive(true);
            foreach (var objectToDisable in objectsToDisableOnDeath)
            {
                if (objectToDisable == null) continue;
                var enableable = objectToDisable.GetComponent<IEnableable>();
                if (enableable == null) continue;
                enableable.Disable();

                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            damageable.Death -= EndGame;
        }

        public void ResetGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }
}
