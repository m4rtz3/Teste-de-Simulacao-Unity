using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miniLanterna : MonoBehaviour
{
    public Mover playerScript;
    public FlashlightOffAndOn LanternonaScript;

    public Light miniFlashlight;
    public GameObject cartao;
    public Rigidbody m_Rb;

    public float onIntensity = 1.5f;
    public float offIntensity = 0f;

    public float sensivityMouseY = 0.1f;
    public float sensivityMouseX = 0.1f;

    public float distanciaX = -0.56f;

    public Quaternion rotacaoDoPlayer = Quaternion.identity;
    public Quaternion rotacaoDaLanterna = Quaternion.identity;
    public Quaternion rotacaoDaLanternaNova = Quaternion.identity;

    private Quaternion currentOrientation = Quaternion.identity;
    private Vector3 lanternaOffset = Vector3.zero;

    public Rotation rotationScript;

    private bool investigacaoAtiva = false;

    // Start is called before the first frame update
    void Start()
    {
        miniFlashlight.intensity = offIntensity;
    }

    // Update is called once per frame
    void Update()
    {
        if (investigacaoAtiva)
        {
            // Ligar a lanterna
            miniFlashlight.intensity = onIntensity;

            // Manipular a lanterna com o mouse
            float xMouseInput = Input.GetAxis("Mouse X") * sensivityMouseX;
            float yMouseInput = Input.GetAxis("Mouse Y") * sensivityMouseY;

            // Atualizar o deslocamento da lanterna com base no movimento do mouse
            lanternaOffset += new Vector3(xMouseInput, yMouseInput, 0);

            // Calcular a nova posição da lanterna
            Vector3 novaPosicaoLanterna = cartao.transform.position + cartao.transform.forward * distanciaX + lanternaOffset;

            //rotacao
            rotacaoDoPlayer = m_Rb.transform.rotation;
            rotacaoDaLanterna = miniFlashlight.transform.rotation;

            Vector3 eulerRotationPlayer = rotacaoDoPlayer.eulerAngles;
            Vector3 eulerRotationLanterna = rotacaoDaLanterna.eulerAngles;

            Vector3 eulerSoma = eulerRotationPlayer + eulerRotationLanterna;
    
            rotacaoDaLanternaNova = Quaternion.Euler(eulerSoma);

            // Atualizar a rotação da lanterna
            miniFlashlight.transform.rotation = rotacaoDaLanternaNova;

            // Atualizar a posição da lanterna
            miniFlashlight.transform.position = novaPosicaoLanterna;

        }
        else
        {
            // Desligar a lanterna quando não estiver em uso
            miniFlashlight.intensity = offIntensity;
        }
    }

    public void modoInvestigas()
    {
        investigacaoAtiva = true;

        if (rotationScript != null)
        {
            rotationScript.Paralisar();
        }

        if (LanternonaScript != null)
        {
            LanternonaScript.modoInvestigacaoLanterna();
        }

        // Posicionar a lanterna
        miniFlashlight.transform.position = cartao.transform.position + cartao.transform.forward * distanciaX;

        // Ligar a lanterna
        miniFlashlight.intensity = onIntensity;

        // Zerar o deslocamento da lanterna quando o modo de investigação é ativado
        lanternaOffset = Vector3.zero;
    }

    public void sairLanterna()
    {
        investigacaoAtiva = false;

        if (rotationScript != null)
        {
            rotationScript.sairParalisar();
        }

        if (playerScript != null)
        {
            playerScript.sairInvestigas();
            playerScript.Movimento();
        }

        // Desligar a lanterna quando não estiver em uso
        miniFlashlight.intensity = offIntensity;

        if (LanternonaScript != null)
        {
            LanternonaScript.sairModoInvestigacaoLanterna();
        }
    }
}