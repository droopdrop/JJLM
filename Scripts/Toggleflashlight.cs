using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggleflashlight : MonoBehaviour
{
    public GameObject flashlight;
    public AudioClip flashlightClick;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            flashlight.GetComponent<Light>().enabled = !flashlight.GetComponent<Light>().enabled;
            audioSource.PlayOneShot(flashlightClick);
        }
    }
}
