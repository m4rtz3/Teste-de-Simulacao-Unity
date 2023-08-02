using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PassagemN1 : MonoBehaviour
{
    public VisibilityController visibilityScript;

    public TextMeshProUGUI textoDaSimulacao;

    private float xSceneTwo = 0.64f;
    private float ySceneTwo = 1f;
    private float zSceneTwo = -229.5627f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.parent != null)
        {
            string parentName = collision.transform.parent.name;

            if (parentName == "Muro com Abertura")
            {
                MuroPassagem();
            }
        }
    }

    public void MuroPassagem()
    {
        textoDaSimulacao.text = "Olha só, essa cerca aqui tem uma passagem.";
        Invoke("ResetTextoMuroPassagem", 3f);
    }

    private void ResetTextoMuroPassagem()
    {
        textoDaSimulacao.text = "Hmm...";
        Invoke("ResetTextoMuroPassagem2", 3f);

        SceneManager.LoadScene("Scene2", LoadSceneMode.Single);

            if (visibilityScript != null)
            {
                visibilityScript.LanternaCenaDois();
            }

        // "spawn"
        transform.position = new Vector3(xSceneTwo,ySceneTwo,zSceneTwo);
    }

    private void ResetTextoMuroPassagem2()
    {
        textoDaSimulacao.text = "";
    }
}