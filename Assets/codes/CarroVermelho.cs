using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CarroVermelho : MonoBehaviour
{
    public TextMeshProUGUI textoDaSimulacao;
    public Mover playerScript;

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
                Invoke("TextoVermelhoDois", 3f);
            }
        }
    }

    private void TextoVermelhoDois()
    {
        textoDaSimulacao.text = "Espera, o que é isso...?";

        if (playerScript != null)
        {
            playerScript.Redirecionar();
        }

        Invoke("TextoVermelhoTres", 3f);
    }

    private void TextoVermelhoTres()
    {
        textoDaSimulacao.text = "Tem algum hotel aqui perto?";
        Invoke("TextoVermelhoQuatro", 3f);
    }

    private void TextoVermelhoQuatro()
    {
        textoDaSimulacao.text = "Que estranho...";
        Invoke("TextoVermelhoCinco", 3f);
    }

    private void TextoVermelhoCinco()
    {
        textoDaSimulacao.text = "Um hotel numa cidade totalmente abandonada.";
        Invoke("ResetTextoCarroVermelho", 3f);
    }

    private void ResetTextoCarroVermelho()
    {
        textoDaSimulacao.text = "";
        tempoInicial = 0f;
        
        carro2Colidido = true;
    }
}
