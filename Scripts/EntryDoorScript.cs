using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryDoorScript : MonoBehaviour
{
    public GameObject entrydoor;
    public GameObject doorlockedTXT;
    Ray fromScreenRay;
    RaycastHit hit; 
    public float interactionDistance = 30f;
    public LayerMask interactablelayer;
    private bool ObjectHit;
    private bool isDoorLocked;
    // Start is called before the first frame update
    void Start()
    {
        isDoorLocked = true;
    }

    // Update is called once per frame
    void Update()
    {
        onHitRaycast();
    }

    void onHitRaycast()
    {
        fromScreenRay = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        if(Physics.Raycast(fromScreenRay, out hit, interactionDistance, interactablelayer))
        {
            ObjectHit = true;
            StartCoroutine(doorLockedTxt());
        }
    }
    IEnumerator doorLockedTxt()
    {
        if(isDoorLocked == true && Input.GetKeyDown(KeyCode.E))
        {
            doorlockedTXT.SetActive(true);
            yield return new WaitForSeconds(4f);
            doorlockedTXT.SetActive(false);
        }
    }
}
