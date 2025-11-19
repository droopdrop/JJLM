using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupKey : MonoBehaviour
{
    public float interactionDistance = 100f;
    public LayerMask interactableLayer;

    public GameObject togglelighttext;
    public GameObject dialoguetext;
    public GameObject keyaddedtxt;
    public GameObject keyaddedDialoguetxt;
    public Camera Camera;
    public GameObject KeyText;
    Ray fromScreenRay;
    RaycastHit hit;
    public GameObject Key;
    AudioSource audioSource;
    public AudioClip pickSFX;
    private bool objectHit;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ToggleText());
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CamRaycast();
        onHitRaycast(Key);
    }
    
    IEnumerator ToggleText()
    {
        dialoguetext.SetActive(true);
        yield return new WaitForSeconds(10f);
        dialoguetext.SetActive(false);

    }

    void CamRaycast()
    {
        
        fromScreenRay = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        if (Physics.Raycast(fromScreenRay, out hit, interactionDistance, interactableLayer))
        {
            Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * interactionDistance, Color.red);
            KeyText.SetActive(true);
            Debug.Log("hit");
            objectHit = true;
        }
        else
        {
            Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * interactionDistance, Color.red);
            KeyText.SetActive(false);
            Debug.Log("did not hit");
            objectHit = false;
        }
    }

    void onHitRaycast(GameObject other)
    {
        if (objectHit == true && Input.GetKeyDown(KeyCode.E))
        {
            if (other.gameObject.tag == "Pickup")
            {
                Key.SetActive(false);
                audioSource.PlayOneShot(pickSFX);
                StartCoroutine(KeyAddedToggleText());
            }
            
        }
    }
    IEnumerator KeyAddedToggleText()
    {
        if (!Key.activeSelf)
        {
            keyaddedDialoguetxt.SetActive(true);
            keyaddedtxt.SetActive(true);
            yield return new WaitForSeconds(4f);
            keyaddedDialoguetxt.SetActive(false);
            keyaddedtxt.SetActive(false);
        }
    }
}
