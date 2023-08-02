using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CarroVermelho : MonoBehaviour
{

    public TextMeshProUGUI textoDaSimulacao;
    private float tempoInicial;
    private bool carro2Colidido = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && !carro2Colidido)
        {
            if (tempoInicial == 0f)
            {
                tempoInicial = Time.time;
                textoDaSimulacao.text = "Deixa eu vasculhar esse carro, hm...";
                Invoke("ResetTextoCarroVermelho", 5f);
            }
        }
    }

    private void ResetTextoCarroVermelho()
    {
        textoDaSimulacao.text = "";
        tempoInicial = 0f;
        
        carro2Colidido = true;
    }
}
