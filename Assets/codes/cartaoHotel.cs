using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cartaoHotel : MonoBehaviour
{
    public Transform cameraVirtual;
    public GameObject cartao;
    public Rigidbody m_Rb;
    public float distanciaZ = 1.46088f;

    public miniLanterna miniLanternascript;

    public Quaternion rotacaoDoPlayer = Quaternion.identity;
    public Quaternion rotacaoDoCartao = Quaternion.identity;
    public Quaternion rotacaoDoCartaoNova = Quaternion.identity;

    public bool modoInvestigacao = false;

    // Start is called before the first frame update
    void Start()
    {
        cartao.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 posicaoCameraVirtual = cameraVirtual.position;
        //Vector3 posicaoCartaoHotel = posicaoCameraVirtual + cameraVirtual.forward * distanciaZ;
        //cartao.transform.position = posicaoCartaoHotel;
        cartao.transform.position = Camera.main.transform.position + Camera.main.transform.forward * distanciaZ;

        if (!modoInvestigacao) {
            if (Input.GetKeyDown(KeyCode.B))
            {
                cartao.SetActive(false);
                
                if (miniLanternascript != null)
                {
                    miniLanternascript.sairLanterna();
                }
            }
        }
    }

    public void cartaoDoHotel() {

        rotacaoDoPlayer = m_Rb.transform.rotation;
        rotacaoDoCartao = cartao.transform.rotation;

        Vector3 eulerRotationPlayer = rotacaoDoPlayer.eulerAngles;
        Vector3 eulerRotationCartao = rotacaoDoCartao.eulerAngles;

        Vector3 eulerSoma = eulerRotationPlayer + eulerRotationCartao;
    
        rotacaoDoCartaoNova = Quaternion.Euler(eulerSoma);

        cartao.transform.rotation = rotacaoDoCartaoNova;

        if (miniLanternascript != null)
        {
            miniLanternascript.modoInvestigas();
        }
        
        cartao.SetActive(true);
        modoInvestigacao = false;
    }
}