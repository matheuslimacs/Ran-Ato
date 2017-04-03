using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour {

    // Referência p/ jogador.
    public GameObject player;

    public float maxTime; // Tempo máximo para ser considerado um Swipe.
    public float minSwipeDist; // Distância mínima para ser considerado um Swipe.

    // Tempo de início e fim do Swipe; distância do Swipe; duração do Swipe
    float startTime;
    float endTime;
    float swipeDistance;
    float swipeTime;

    // Posição de início e fim do Swipe
    Vector3 startPos;
    Vector3 endPos;

    private void Update()
    {
        if (Input.touchCount > 0) // Detectar se há pelo menos um toque
        {
            Touch touch = Input.GetTouch(0); // Alocando essa verificação em uma variável

            if (touch.phase == TouchPhase.Began) // Verificando se a 'fase' do toque é a fase inicial (começamos a tocar)
            {
                startTime = Time.time;
                startPos = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended) // Verificando se a 'fase' do toque é a fase final (terminamos de tocar)
            {
                endTime = Time.time;
                endPos = touch.position;

                swipeDistance = (endPos - startPos).magnitude;
                swipeTime = endTime - startTime;

                if (swipeTime < maxTime && swipeDistance > minSwipeDist)
                {
                    Swiping();
                }
            }
        }
    }

    void Swiping()
    {
        Vector2 distance = endPos - startPos;
        if (Mathf.Abs(distance.x) > Mathf.Abs(distance.y))
        {
            Debug.Log("Horizontal");

            if (distance.x > 0)
            {
                Debug.Log("P/ direita");
            }

            if (distance.x < 0)
            {
                Debug.Log("P/ esquerda");
            }
        }
        else if (Mathf.Abs(distance.x) < Mathf.Abs(distance.y))
        {
            Debug.Log("Vertical");

            if (distance.y > 0)
            {
                Debug.Log("P/ cima");
            }

            if (distance.y < 0)
            {
                Debug.Log("P/ baixo");
                player.GetComponent<MovePlayer>().isGoingDown = true;
                player.GetComponent<MovePlayer>().GoDown();
            }
        }
    }

}
