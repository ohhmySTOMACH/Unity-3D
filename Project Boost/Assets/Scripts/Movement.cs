using UnityEngine;

namespace Rocket
{
    public class Movement : MonoBehaviour
    {
        
        [SerializeField] AudioClip m_audioClip;
        [SerializeField] float mainThrust = 150f;
        [SerializeField] float rotationThrust = 100f;
        
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
                // (0,1,0)
                movementRigidbody.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);

                if(!m_audioSource.isPlaying)
                {
                    m_audioSource.PlayOneShot(m_audioClip);
                }
            }
            else
            {
                m_audioSource.Stop();
            }
        }

        void ProcessRotation()
        {
            if(Input.GetKey(KeyCode.A))
            {
                // Freeze rotation so we can manually rotate
                movementRigidbody.freezeRotation = true;

                // Or (0,0,zAngle)
                transform.Rotate(Vector3.forward * rotationThrust * Time.deltaTime);

                // Unfreeze rotation so that physics system can take over
                movementRigidbody.freezeRotation = false; 
            }
            else if(Input.GetKey(KeyCode.D))
            {
                movementRigidbody.freezeRotation = true;
                transform.Rotate(Vector3.back * rotationThrust * Time.deltaTime);
                movementRigidbody.freezeRotation = false;
            }
        }
    }
}
