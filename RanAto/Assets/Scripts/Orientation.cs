using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orientation : MonoBehaviour {

    // Apenas 'travando' a tela na orientação Retrato.
    private void Update()
    {
        Screen.orientation = ScreenOrientation.Portrait;
    }
}
