using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibilityController : MonoBehaviour
{
    public Texto textoScript;
    private bool carro1Colidido = false;

    // declarar o braço direito normal
    public GameObject braçoDireito;

    // e o braço com a lanterna
    public GameObject braçoDireitoComLanterna;
    
    private void Start()
    {
        // o braço normal aparece no start
        braçoDireito.SetActive(true);
        // enquanto com a lanterna nao
        braçoDireitoComLanterna.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // apos colidir com o primeiro carro...
        if (collision.gameObject.name == "Carro1" && !carro1Colidido)
        {
            if (textoScript != null)
            {
                textoScript.CarroLanterna();
            }

            // braco normal some
            braçoDireito.SetActive(false);
            // para que o segurando a lanterna surja
            braçoDireitoComLanterna.SetActive(true);

            // marca a colisão com o Carro1 como ocorrida
            carro1Colidido = true;
        }
    }

    public void LanternaCenaDois()
    {
        // o braço normal aparece no start
        braçoDireito.SetActive(true);
        // enquanto com a lanterna nao
        braçoDireitoComLanterna.SetActive(false);
    }
}
