using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using UnityEngine.SceneManagement;
public class MenuScript : MonoBehaviour
{

    public TextMeshProUGUI newgametxt;
    public TextMeshProUGUI quitTxt;
    AudioSource audioSource;
    public AudioClip selectSFX;
    public AudioClip clickSFX;
    public GameObject mainCam;
    void Start() 
    {
        audioSource = mainCam.GetComponent<AudioSource>();
    }



    //perhaps later overhaul with a tag assignment system next time??
    public void PointerEnter()
    {
        newgametxt.GetComponent<TextMeshProUGUI>().text = "[NEW GAME]";
        audioSource.PlayOneShot(selectSFX);
    }

    public void PointerExit()
    {
        newgametxt.GetComponent<TextMeshProUGUI>().text = "NEW GAME";
    }
    public void quitEnter()
    {
        quitTxt.GetComponent<TextMeshProUGUI>().text = "[QUIT]";
        audioSource.PlayOneShot(selectSFX);
    }
    public void quitExit()
    {
        quitTxt.GetComponent<TextMeshProUGUI>().text = "QUIT";

    }
    public void PointerClick()
    {
        SceneManager.LoadScene(1);
        audioSource.PlayOneShot(clickSFX);
    }
    public void quitClick()
    {
        Application.Quit();
        Debug.Log("quitting application!");
        audioSource.PlayOneShot(clickSFX);
    }
}
