using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDialogueScript : MonoBehaviour
{
    public GameObject frontdoor;
    public GameObject frontdoor2;
    Ray fromScreenRay;
    RaycastHit hit;

    public GameObject frontdoortxt;
    public float interactionDistance = 30f;
    public LayerMask interactableLayer;
    private bool objectHit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        onHitRaycast();
    }

    void onHitRaycast()
    {
        fromScreenRay = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        if (Physics.Raycast(fromScreenRay, out hit, interactionDistance, interactableLayer))
        {
            objectHit = true;
            activatedoor();
        }
    }
    void activatedoor()
    {
        if(objectHit == true && Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(dialoguetextsecs());
        }
    }
    IEnumerator dialoguetextsecs()
    {
        frontdoortxt.SetActive(true);
        yield return new WaitForSeconds(3f);
        frontdoortxt.SetActive(false);
    }
}
