using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Cartas : MonoBehaviour
{
    private float xAngle = 0;
    private float yAngle = 0.1f;
    private float zAngle = 0;

    public string tagCartas;

    public TextMeshProUGUI textoDaSimulacao;
    private float tempoInicial;

    void Update()
    {
        RotateCardsByTag();
    }

    private void RotateCardsByTag()
    {
        GameObject[] cartas = GameObject.FindGameObjectsWithTag("Carta");

        foreach (GameObject carta in cartas)
        {
            carta.transform.Rotate(xAngle, yAngle, zAngle);
        }
    }

    public void CartasToMover()
    {
        if (tempoInicial == 0f)
        {
            tempoInicial = Time.time;
            textoDaSimulacao.text = "Olha, uma fita...";

            Invoke("ResetTextoCarta", 5f);
        }
    }

    private void ResetTextoCarta()
    {
        textoDaSimulacao.text = "";
        tempoInicial = 0f;
    }

}