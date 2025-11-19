using UnityEngine;

public class Changefootsteps : MonoBehaviour
{
    FirstPersonAudio fpaudio;
    AudioSource audioSource;
    public AudioClip grassfootsteps;
    public AudioClip concretefootsteps;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        fpaudio = Player.GetComponent<FirstPersonAudio>();
        audioSource = Player.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    void OnCollisionEnter(Collision other) 
    {
        if (this.gameObject.tag == "Concrete" && other.gameObject.tag == ("Player"))
        {
            audioSource.PlayOneShot(concretefootsteps);
            Debug.Log("works");

        }
        else if (this.gameObject.tag == "grass" && other.gameObject.tag == ("Player"))
        {
            audioSource.PlayOneShot(grassfootsteps);

        }
    }

}
