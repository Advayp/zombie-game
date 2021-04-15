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
        [SerializeField] private GameObject enemySpawner;

        private ISpawner _spawner;
        private IDamageable _damageable;

        private void Awake()
        {
            _damageable = player.GetComponent<IDamageable>();
            _spawner = enemySpawner.GetComponent<ISpawner>();
            objectsToDisableOnDeath = GameObject.FindGameObjectsWithTag("enableable");
        }

        private void Start()
        {
            _damageable.Death += EndGame;
        }

        public void EndGame()
        {
            gameEndedUI.SetActive(true);
            foreach (var objectToDisable in objectsToDisableOnDeath)
            {
                _spawner.IsSpawning = false;
                if (objectToDisable == null) continue;
                var enableable = objectToDisable.GetComponent<IEnableable>();
                if (enableable == null) continue;
                enableable.Disable();

                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            _damageable.Death -= EndGame;
        }

        public void ResetGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }
}
