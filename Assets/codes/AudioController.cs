using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AudioController : MonoBehaviour
{
    public AudioSource audioFitaUm;
    public AudioClip clip;

    public TextMeshProUGUI textoDaSimulacao;
    private float tempoInicial;

    void Start()
    {
        audioFitaUm = GetComponent<AudioSource>();
        audioFitaUm.clip = clip;
    }

    void Update()
    {
        // Check for the "P" key press to play the audio
        if (Input.GetKeyDown(KeyCode.P))
        {
            TocarFitaUmP();
        }
    }

    public void TocarFitaUm()
    {
        if (tempoInicial == 0f)
        {
            tempoInicial = Time.time;
            textoDaSimulacao.text = "Aperte [P] para dar Play!";
            Invoke("ResetTextoAudioUm", 5f);
        }
    }

    private void TocarFitaUmP()
    {
        // Play the audio when "P" is pressed
        if (!audioFitaUm.isPlaying)
        {
            audioFitaUm.Play();
        } else {
            audioFitaUm.Pause();
        }
    }

    private void ResetTextoAudioUm()
    {
        textoDaSimulacao.text = "";
        tempoInicial = 0f;
    }
}