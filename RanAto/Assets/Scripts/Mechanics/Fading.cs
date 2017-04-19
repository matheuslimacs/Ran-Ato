using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fading : MonoBehaviour {

    public Texture2D fadeOutTexture;
    public float fadeSpeed = 0.8f;

    private int drawDepth = -1000;
    private float alpha = 1.0f;
    private int fadedir = -1;

    private void OnGUI()
    {
        alpha += fadedir * fadeSpeed * Time.deltaTime;
        alpha = Mathf.Clamp01(alpha);

        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        GUI.depth = drawDepth;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture);
    }

    public float BeginFade(int direction)
    {
        fadedir = direction;
        return (fadeSpeed);
    }

    private void LoadedLevel(Scene level, LoadSceneMode mode)
    {
        BeginFade(-1);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += LoadedLevel;
    }

}
