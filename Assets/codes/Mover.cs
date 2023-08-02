using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Mover : MonoBehaviour
{
    public Cartas cartasScript;
    public ScoreCartas scoreCartasScripts;

    public Texto textoScript;

    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float rotationSpeed = 5f;

    private float xReset = 0f;
    private float yReset = -0.4565005f;
    private float zReset = -61.9f;

    public float forcaDeSalto = 5f;
    private Rigidbody m_Rb;

    private Vector3 playerVelocity;

    // Start is called before the first frame update
    void Start()
    {
        // "spawn"
        transform.position = new Vector3(xReset,yReset,zReset);

        //declarando o corpo rigido do character e o utilizando
        m_Rb = GetComponent<Rigidbody>();
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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Saltar();
        }
    }

    //metodo movimento
    void Movimento() {
        //temos aqui que a posicao x altera de acordo com o input horizontal do unity, assim como a posicao z
        float xValue = Input.GetAxis("Horizontal") * moveSpeed * moveSpeed * moveSpeed * moveSpeed * moveSpeed * moveSpeed * moveSpeed * moveSpeed * Time.deltaTime;
        float zValue = Input.GetAxis("Vertical") * moveSpeed * moveSpeed * moveSpeed * moveSpeed * moveSpeed * moveSpeed * moveSpeed * moveSpeed * Time.deltaTime;

        // assim por frame, a posição se altera assim
        Vector3 movement = new Vector3(xValue, 0, zValue).normalized;

        if (movement == Vector3.zero)
        {
            return;
        }

        // isso tudo para que o personagem rotacione quando é clicado as setas lá
        Quaternion targetRotation = Quaternion.LookRotation(movement);
        
        targetRotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 360 * rotationSpeed * Time.fixedDeltaTime);

        m_Rb.MovePosition(m_Rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        m_Rb.MoveRotation(targetRotation);
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
                Destroy(collision.gameObject);

                if (cartasScript != null)
                {
                    cartasScript.CartasToMover();
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
