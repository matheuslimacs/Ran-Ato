using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selecionar : MonoBehaviour {

    private Animation doorL;
    private Animation doorR;

    private void Start()
    {
        doorL = GameObject.Find("doorL").GetComponent<Animation>();
        doorR = GameObject.Find("doorR").GetComponent<Animation>();
    }

    public void Japonesa()
    {
        GameManager.character = 1;
        doorL.Play("DoorLSlideIn");
        doorR.Play("DoorRSlideIn");
    }

    public void Samurai()
    {
        GameManager.character = 2;
        doorL.Play("DoorLSlideIn");
        doorR.Play("DoorRSlideIn");
    }

    public void Ninja()
    {
        GameManager.character = 3;
        doorL.Play("DoorLSlideIn");
        doorR.Play("DoorRSlideIn");
    }
}
