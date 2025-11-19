using UnityEngine;
public class FirstPersonAudio : MonoBehaviour
{
    FirstPersonMovement firstpersonmovement;
    AudioSource audioSource;
    public float volume = 0.7f;
    private float timeBetweenSteps = 0.5f;
    private float nextFootstepTime;
    [Range(0.5f, 2f)]
    [SerializeField] private float pitchRange;
    [Header("Footstep Parameters")]
    [SerializeField] private AudioClip grassfootsteps;
    [SerializeField] private AudioClip concretefootsteps;
    [SerializeField] private AudioClip gravelfootsteps;

    public string currentMaterialTag = "";
    // Start is called before the first frame update
    void Start()
    {
        firstpersonmovement = GetComponent<FirstPersonMovement>();
        audioSource = GetComponent<AudioSource>();
        audioSource.pitch = pitchRange;
        audioSource.volume = volume;
    }

    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            if (Time.time > nextFootstepTime)
            {
                nextFootstepTime = Time.time + timeBetweenSteps;
                PlayAudio();

            }
        }
    }

    void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.tag == "Concrete")
        {
            currentMaterialTag = "Concrete";
        }
        if (other.gameObject.tag == "grass")
        {
            currentMaterialTag = "grass";
        }
        if (other.gameObject.tag == "Gravel")
        {
            currentMaterialTag = "Gravel";
        }
        if (currentMaterialTag == "grass" && other.gameObject.tag == "Concrete")
        {
            currentMaterialTag = "Concrete";
        }
        if(currentMaterialTag == "Concrete" && other.gameObject.tag == "grass")
        {
            currentMaterialTag = "grass";
        }
    }
    

    void PlayAudio()
    {

        switch (currentMaterialTag)
        {
            case "Concrete":
                audioSource.PlayOneShot(concretefootsteps);
                Debug.Log("working concrete");
                break;
            case "grass":
                audioSource.PlayOneShot(grassfootsteps);
                Debug.Log("working grass");
                break;
            case "Gravel":
                audioSource.PlayOneShot(gravelfootsteps);
                Debug.Log("working gravel");
                break;
            default:
                audioSource.PlayOneShot(concretefootsteps);
                Debug.Log("reverting to default noise");
                break;
        }
    }
}
