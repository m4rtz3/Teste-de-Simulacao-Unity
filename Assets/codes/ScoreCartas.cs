using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCartas : MonoBehaviour
{
    int cartasEncontradas = 0;
    int totalCartas;

    public TextMeshProUGUI textoCartasEncontradas;
    private float tempoInicialCartasScore;

    void Start ()
    {
        totalCartas = GameObject.FindGameObjectsWithTag("Carta").Length;
    }

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void scoreCartasEncontradas()
    {
        cartasEncontradas++;

        if (tempoInicialCartasScore == 0f)
        {
            tempoInicialCartasScore = Time.time;
            textoCartasEncontradas.text = cartasEncontradas + "/" + totalCartas + " FITAS!";
            Invoke("ResetTextoCartasScore", 5f);
        }
    }

    private void ResetTextoCartasScore()
        {
            textoCartasEncontradas.text = "";
            tempoInicialCartasScore = 0f;
        }
}