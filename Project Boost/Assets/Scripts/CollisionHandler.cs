using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Rocket
{

    public class CollisionHandler : MonoBehaviour
    {
        [SerializeField] float delayTime = 1f;
        [SerializeField] AudioClip crashAudio;
        [SerializeField] AudioClip successAudio;
        [SerializeField] ParticleSystem crashParticle;
        [SerializeField] ParticleSystem successParticle;

        Movement movement;
        AudioSource m_audioSource;
        
        bool isTransitioning = false;
        bool collisionDisable = false;

        void Start()
        {
            m_audioSource = GetComponent<AudioSource>();
        }

        void Update()
        {
            RespondToDebugKeys();
        }
         void RespondToDebugKeys()
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                collisionDisable = !collisionDisable;
            } 
            if (Input.GetKeyDown(KeyCode.L))
            {
                LoadNextLevel();
            }
        }

        void OnCollisionEnter(Collision other) {
            if (!isTransitioning && !collisionDisable)
            {
                m_audioSource.Stop();
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
        }

        void StartSuccessSequence()
        {
            isTransitioning = true;
            movement = GetComponent<Movement>();
            movement.enabled = false;
            m_audioSource.PlayOneShot(successAudio);
            successParticle.Play();
            Invoke("LoadNextLevel", delayTime);
        }

        void StartCrashSequence()
        {
            isTransitioning = true;
            movement = GetComponent<Movement>();
            movement.enabled = false;
            m_audioSource.PlayOneShot(crashAudio);
            crashParticle.Play();
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
