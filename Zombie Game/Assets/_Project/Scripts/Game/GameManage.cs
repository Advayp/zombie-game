namespace Zombie.Game
{
    using UnityEngine;
    using UnityEngine.SceneManagement;
    using Zombie.Core;
    public class GameManage : MonoBehaviour
    {
        [SerializeField] private GameObject player;
        [SerializeField] private GameObject[] objectsToDisableOnDeath;


        private IDamageable damageable;

        private void Awake()
        {
            damageable = player.GetComponent<IDamageable>();
            objectsToDisableOnDeath = GameObject.FindGameObjectsWithTag("enableable");
        }

        private void Update()
        {
            if (damageable == null) return;
            if (!damageable.IsDead) return;

            if (Input.GetKeyDown(KeyCode.R))
            {
                ResetGame();
            }

            EndGame();
        }

        private void EndGame()
        {
            foreach (var objectToDisable in objectsToDisableOnDeath)
            {
                var enableable = objectToDisable.GetComponent<IEnableable>();
                if (enableable == null) continue;

                enableable.Disable();
            }
        }

        public void ResetGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }
}
