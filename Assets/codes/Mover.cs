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

    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float rotationSpeed = 25f;

    private Quaternion currentOrientation = Quaternion.identity;

    private float xReset = 0f;
    private float yReset = -0.4565005f;
    private float zReset = -61.9f;

    public float sensivityMouseY = .5f;
    public float sensivityMouseX = .5f;

    private int reset = 0;

    public float forcaDeSalto = 5f;
    private Rigidbody m_Rb;

    private Vector3 playerVelocity;

    // Start is called before the first frame update
    void Start()
    {
        
        Cursor.lockState = CursorLockMode.Locked;

        // "spawn"
        transform.position = new Vector3(xReset,yReset,zReset);

        //declarando o corpo rigido do character e o utilizando
        m_Rb = GetComponent<Rigidbody>();

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
    void Movimento() {
        float xArrowInput = Input.GetAxis("Horizontal");
        float zArrowInput = Input.GetAxis("Vertical");

        float xMouseInput = Input.GetAxis("Mouse X") * sensivityMouseX;
        //float yMouseInput = Input.GetAxis("Mouse Y") * sensivityMouseY;

        float xValue = xArrowInput * moveSpeed * Time.deltaTime;
        float zValue = zArrowInput * moveSpeed * Time.deltaTime;

        Vector3 arrowMovement = currentOrientation * new Vector3(xValue, 0, zValue).normalized;

            m_Rb.MovePosition(m_Rb.position + arrowMovement * moveSpeed * Time.fixedDeltaTime);
        
            // Calculate the rotation based on mouse input
            float rotationAmountY = xMouseInput * rotationSpeed * rotationSpeed * Time.deltaTime * 5f; // Increase rotation speed
            //float rotationAmountX = -yMouseInput * rotationSpeed * Time.deltaTime * 5f; // Increase rotation speed

            Vector3 rotationVector = new Vector3(0, rotationAmountY, 0);
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
                Destroy(collision.gameObject, 0.1f);

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
}
