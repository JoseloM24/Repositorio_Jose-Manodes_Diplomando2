using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiveImage : MonoBehaviour
{
    public GameObject[] vidas;

    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

    }
    public void DesactivarVida(int indice)
    {
        vidas[indice].SetActive(false);
    }
    public void ActivarVida(int indice)
    {
        vidas[indice].SetActive(true);
    }
}