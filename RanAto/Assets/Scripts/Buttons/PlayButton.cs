using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayButton : MonoBehaviour {

    public Animation doorL;
    public Animation doorR;

    public void Historia()
    {
        StartCoroutine(GoToScene());
        
    }

    private IEnumerator GoToScene()
    {
        doorL.Play();
        doorR.Play();
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("MainGame");
    }
}
