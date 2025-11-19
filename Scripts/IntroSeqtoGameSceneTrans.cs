using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class IntroSeqtoGameSceneTrans : MonoBehaviour
{
    void Update()
    {
        StartCoroutine(timeToSceneChange());
    }
    IEnumerator timeToSceneChange()
    {
        yield return new WaitForSeconds(95f);
        SceneManager.LoadScene(2);
    }
}
