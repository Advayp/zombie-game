using UnityEngine;
using UnityEngine.SceneManagement;
using Zombie.Core;

namespace Zombie.Game
{
    public class GameManage : MonoBehaviour
    {
        [SerializeField] private GameObject player;
        [SerializeField] private GameObject gameEndedUI;
        [SerializeField] private GameObject[] objectsToDisableOnDeath;
        [SerializeField] private GameObject enemySpawner;

        private ISpawner spawner;
        private IDamageable damageable;

        private void Awake()
        {
            damageable = player.GetComponent<IDamageable>();
            spawner = enemySpawner.GetComponent<ISpawner>();
            objectsToDisableOnDeath = GameObject.FindGameObjectsWithTag("enableable");
        }

        private void Start()
        {
            EnemyController.KillCount = 0;
            damageable.Death += EndGame;
        }

        private void EndGame()
        {
            gameEndedUI.SetActive(true);
            foreach (var objectToDisable in objectsToDisableOnDeath)
            {
                spawner.IsSpawning = false;
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
