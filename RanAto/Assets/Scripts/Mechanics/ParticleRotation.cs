using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleRotation : MonoBehaviour {

    private void Start()
    {
        transform.eulerAngles = new Vector2(-93, transform.eulerAngles.y);
    }
}
