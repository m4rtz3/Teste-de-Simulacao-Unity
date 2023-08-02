using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Texto : MonoBehaviour
{
    public TextMeshProUGUI textoDaSimulacao;

    private float tempoInicial;

    private float tempoInicialCalcada;
    private float tempoInicialMuroN;
    
    // Start is called before the first frame update
    void Start()
    {
        tempoInicial = Time.time;
    }

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void inicioJogo()
    {
        float tempoDecorrido = Time.time - tempoInicial;

        if (tempoDecorrido >= 0f && tempoDecorrido < 3f)
        {
            textoDaSimulacao.text = "Esse é o primeiro teste de uma simulação.";
        }
        else if (tempoDecorrido >= 3f && tempoDecorrido < 6f)
        {
            textoDaSimulacao.text = "Se mexa usando as setas no computador!";
        }
        else if (tempoDecorrido >= 6f && tempoDecorrido < 9f)
        {
            textoDaSimulacao.text = "E explore essa rua abandonada...";
        }
        else if (tempoDecorrido >= 9f)
        {
            textoDaSimulacao.text = "";
        }
    }

    public void CalcadaTexto()
    {
        if (tempoInicialCalcada == 0f)
        {
            tempoInicialCalcada = Time.time;
            textoDaSimulacao.text = "Talvez não seja uma boa ideia sair da rua...";
            Invoke("ResetTextoCalcada", 5f);
        }
    }

    private void ResetTextoCalcada()
    {
        textoDaSimulacao.text = "";
        tempoInicialCalcada = 0f;
    }

    public void MuroNormalTexto()
    {
        if (tempoInicialMuroN == 0f)
        {
            tempoInicialMuroN = Time.time;
            textoDaSimulacao.text = "Essa parte da rua está fechada, que estranho.";
            Invoke("ResetTextoMuroNormal", 5f);
        }
    }

    private void ResetTextoMuroNormal()
    {
        textoDaSimulacao.text = "";
        tempoInicialMuroN = 0f;
    }

    public void CarroLanterna()
    {
        textoDaSimulacao.text = "Vamos checar esse carro...";
        Invoke("ResetTextoCarroLanterna", 3f); // 3 frames (3/60 segundos)
    }

    private void ResetTextoCarroLanterna()
    {
        textoDaSimulacao.text = "Olha uma lanterna!";
        Invoke("ResetTextoCarroLanterna2", 3f); // 3 frames (3/60 segundos)
    }

    private void ResetTextoCarroLanterna2()
    {
        textoDaSimulacao.text = "É só pressionar [F] para ligar e desligar.";
        Invoke("ResetTextoCarroLanterna3", 3f); // 3 frames (3/60 segundos)
    }

    private void ResetTextoCarroLanterna3()
    {
        textoDaSimulacao.text = "No começo às vezes falha, mas uma hora funciona!";
        Invoke("ResetTextoCarroLanterna4", 3f); // 3 frames (3/60 segundos)
    }

    private void ResetTextoCarroLanterna4()
    {
        textoDaSimulacao.text = "";
    }

    void Update()
    {
        float tempoDecorrido = Time.time - tempoInicial;

        if (tempoDecorrido <= 11f)
        {
            inicioJogo();
        }
    }
}
