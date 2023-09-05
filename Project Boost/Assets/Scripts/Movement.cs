using UnityEngine;

namespace Rocket
{
    public class Movement : MonoBehaviour
    {
        
        [SerializeField] AudioClip m_audioClip;
        [SerializeField] float mainThrust = 150f;
        [SerializeField] float rotationThrust = 100f;
        [SerializeField] ParticleSystem leftBooster;
        [SerializeField] ParticleSystem rightBooster;
        [SerializeField] ParticleSystem mainBooster;
        
        AudioSource m_audioSource;
        Rigidbody movementRigidbody;


        // Start is called before the first frame update
        void Start()
        {
            movementRigidbody = GetComponent<Rigidbody>();
            m_audioSource = GetComponent<AudioSource>();
        }

        // Update is called once per frame
        void Update()
        {
            ProcessThrust();
            ProcessRotation();
        }

       

        void ProcessThrust()
        {
            if (Input.GetKey(KeyCode.Space))
            {
                StartThrusting();
            }
            else
            {
                StopThrusting();
            }
        }

        void StartThrusting()
        {
            // (0,1,0)
            movementRigidbody.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);

            if (!m_audioSource.isPlaying)
            {
                m_audioSource.PlayOneShot(m_audioClip);
            }

            if (!mainBooster.isPlaying)
            {
                mainBooster.Play();
            }
        }
        void StopThrusting()
        {
            m_audioSource.Stop();
            mainBooster.Stop();
        }

    

        void ProcessRotation()
        {
            if(Input.GetKey(KeyCode.A))
            {
                RotateLeft();
            }
            else if(Input.GetKey(KeyCode.D))
            {
                RotateRight();
            }
            else
            {
                StopRotating();
            }
        }

        void RotateLeft()
        {
            // Freeze rotation so we can manually rotate
            movementRigidbody.freezeRotation = true;

            // Or (0,0,zAngle)
            transform.Rotate(Vector3.forward * rotationThrust * Time.deltaTime);

            // Unfreeze rotation so that physics system can take over
            movementRigidbody.freezeRotation = false;
            if (!rightBooster.isPlaying)
            {
                rightBooster.Play();
            }
        }

        void RotateRight()
        {
            movementRigidbody.freezeRotation = true;
            transform.Rotate(Vector3.back * rotationThrust * Time.deltaTime);
            movementRigidbody.freezeRotation = false;

            if (!leftBooster.isPlaying)
            {
                leftBooster.Play();
            }
        }

        void StopRotating()
        {
            leftBooster.Stop();
            rightBooster.Stop();
        }

        
    }
}
