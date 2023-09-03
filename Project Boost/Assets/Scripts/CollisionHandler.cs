using UnityEngine;
using UnityEngine.SceneManagement;

namespace Rocket
{

    public class CollisionHandler : MonoBehaviour
    {
        [SerializeField] float delayTime = 1f;
        Movement movement;
        void OnCollisionEnter(Collision other) {
            switch (other.gameObject.tag)
            {
                case "Finish":
                    StartSuccessSequence();
                    break;
                case "Friendly":
                    Debug.Log("This thing is friendly");
                    break;
                default:
                    StartCrashSequence();
                    break;
            }
        }

        void StartSuccessSequence()
        {
            movement = GetComponent<Movement>();
            movement.enabled = false;
            Invoke("LoadNextLevel", delayTime);
        }

        void StartCrashSequence()
        {
            movement = GetComponent<Movement>();
            movement.enabled = false;
            Invoke("ReloadLevel", delayTime);
        }

        void ReloadLevel()
        {
            // SceneManager.LoadScene("Sandbox"); 
            // pass 0 as index also work
            // Pass as Variable
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex);
        }

        void LoadNextLevel()
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            int nextSceneIndex = currentSceneIndex + 1;
            if(nextSceneIndex == SceneManager.sceneCountInBuildSettings)
            {
                nextSceneIndex = 0;
            }
            SceneManager.LoadScene(nextSceneIndex);
        }
    }
}