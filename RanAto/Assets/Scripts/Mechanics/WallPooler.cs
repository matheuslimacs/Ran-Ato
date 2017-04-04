using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallPooler : MonoBehaviour {

    // Esse script irá limitar o número de plataformas criadas a 5.
    // Esse processo se chama "Pooling", serve para limitar o uso de "Instantiate" e "Destroy" (funções que consomem memória ao longo do tempo).
    // Dessa forma, usaremos apenas 5, funciona como se fosse uma fila em FIFO (first-in/first-out).
    // O primeiro objeto a ser criado ficará no fim da fila após o 5º objeto ser criado.
    // EX.: O primeiro objeto tomara o lugar do 5º, a posição do 5º objeto foi p/ 4º, empurrando todos os subsequentes (4º p/ 3º, 3º p/ 2º...)
    // Dessa forma, não criamos mais itens, só mudamos sua posição.
    // Para evitar instanciar mais de 5, o primeiro objeto será posicionado no lugar do 5º consecutivas vezes (e isso o jogador não vê).

    public GameObject pooledObject;

    public int pooledAmount;

    List<GameObject> pooledObjects;

    private void Start()
    {
        pooledObjects = new List<GameObject>();

        for (int i = 0; i < pooledAmount; i++)
        {
            GameObject obj = Instantiate(pooledObject) as GameObject;
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        foreach (GameObject platform in pooledObjects)
        {
            if (!platform.activeInHierarchy)
            {
                return platform;
            }
        }

        GameObject obj = Instantiate(pooledObject) as GameObject;
        obj.SetActive(false);
        pooledObjects.Add(obj);
        return obj;
    }

}
