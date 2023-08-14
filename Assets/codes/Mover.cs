using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Mover : MonoBehaviour
{
    public Cartas cartasScript;
    public ScoreCartas scoreCartasScripts;
    public Texto textoScript;
    public AudioController audioControlScript;
    public Rotation rotationScript;
    public cartaoHotel cartaoHScript;

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotationSpeed = 25f;

    private Quaternion currentOrientation = Quaternion.identity;

    private float xReset = 0f;
    private float yReset = -0.4565005f;
    private float zReset = -61.9f;

    public float sensivityMouseX = .5f;

    public float forcaDeSalto = 5f;
    private Rigidbody m_Rb;

    private Vector3 playerVelocity;

    private bool podeMover = true;

    // Start is called before the first frame update
    void Start()
    {
        
        Cursor.lockState = CursorLockMode.Locked;

        // "spawn"
        transform.position = new Vector3(xReset,yReset,zReset);

        //declarando o corpo rigido do character e o utilizando
        m_Rb = GetComponent<Rigidbody>();

        m_Rb.constraints = RigidbodyConstraints.FreezeRotation;

        currentOrientation = transform.rotation;
    }

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        //metodo de movimento do character
        Movimento();

        if (rotationScript != null)
        {
            rotationScript.Rotacao();
        }

        if (rotationScript != null)
        {
            rotationScript.Start();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Saltar();
        }
    }

    //metodo movimento
    public void Movimento() {
        if (!podeMover) return;

        float xArrowInput = Input.GetAxis("Horizontal");
        float zArrowInput = Input.GetAxis("Vertical");

        float xMouseInput = Input.GetAxis("Mouse X") * sensivityMouseX;

        float xValue = xArrowInput * moveSpeed * Time.deltaTime;
        float zValue = zArrowInput * moveSpeed * Time.deltaTime;

        Vector3 arrowMovement = currentOrientation * new Vector3(xValue, 0, zValue).normalized;

        m_Rb.MovePosition(m_Rb.position + arrowMovement * moveSpeed * Time.fixedDeltaTime);
        
        // Calculate the rotation based on mouse input
        float rotationAmountX = xMouseInput * rotationSpeed * rotationSpeed * Time.deltaTime * 5f;

        Vector3 rotationVector = new Vector3(0, rotationAmountX, 0);
        Quaternion rotationDelta = Quaternion.Euler(rotationVector);
        m_Rb.MoveRotation(m_Rb.rotation * rotationDelta);

        currentOrientation = m_Rb.rotation;
        
    }
    
    void Saltar()
    {
        m_Rb.AddForce(Vector3.up * forcaDeSalto, ForceMode.Impulse);
    }

    // os efeitos após o character colidir com certos elementos, quando só aparece mensagens
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.parent != null)
        {
            string parentName = collision.transform.parent.name;

            //tempoInicial = Time.time;
            //float tempoDecorrido = Time.time - tempoInicial;

            //if (collision.gameObject.CompareTag("Carta"))
            if (parentName == "Carta")
            {
                GameObject fitaColidida = collision.gameObject;

                Vector3 novaPosicao = new Vector3(0f, 1000f, 0f);

                fitaColidida.transform.position = novaPosicao;

                // Desativar renderizadores
                Renderer[] renderers = fitaColidida.GetComponentsInChildren<Renderer>();
                foreach (Renderer renderer in renderers)
                {
                    renderer.enabled = false;
                }

                // Desativar colisores
                Collider[] colliders = fitaColidida.GetComponentsInChildren<Collider>();
                foreach (Collider collider in colliders)
                {
                    collider.enabled = false;
                }

                // Executar ações relacionadas à carta (se necessário)

                // Desativar o objeto (opcional)
                fitaColidida.SetActive(false);

                if (cartasScript != null)
                {
                    cartasScript.CartasToMover();
                }

                if (audioControlScript != null)
                {
                    audioControlScript.TocarFitaUm();
                }

                if (scoreCartasScripts != null)
                {
                    scoreCartasScripts.scoreCartasEncontradas();
                }

                // Destruir o objeto após um curto intervalo de tempo
                Destroy(fitaColidida, 0.1f);

            }
            else if (parentName == "Calcada")
            {

                if (textoScript != null)
                {
                    textoScript.CalcadaTexto();
                }
            }
            else if (parentName == "Muro Normal")
            {

                if (textoScript != null)
                {
                    textoScript.MuroNormalTexto();
                }
            }
        }
    }

    public void Redirecionar()
    {
        Vector3 redirecionamento = new Vector3(0, 0, 0);
        Quaternion rotationDelta = Quaternion.Euler(redirecionamento);
        
        m_Rb.constraints = RigidbodyConstraints.FreezeAll;

        podeMover = false;

        if (cartaoHScript != null)
        {
            cartaoHScript.cartaoDoHotel();
        }
    }

    public void sairInvestigas()
    {
        m_Rb.constraints = RigidbodyConstraints.None;
        m_Rb.constraints = RigidbodyConstraints.FreezeRotation;

        podeMover = true;
    }
}
