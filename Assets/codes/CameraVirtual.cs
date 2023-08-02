using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class CameraVirtual : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

//    public CinemachineVirtualCamera virtualCamera;
//    public Movimento2 movimentoCenaDoisScript;
//
//    public void mudancaCenas()
//    {
//        SceneManager.LoadScene("Scene2", LoadSceneMode.Additive);
//
//        if (movimentoCenaDoisScript != null)
//        {
//            movimentoCenaDoisScript.MovimentoCenaDois();
//        }
//                    
//        GameObject gameObjectToFollow = GameObject.FindGameObjectWithTag("Lente");
//        if (gameObjectToFollow != null)
//        {
//            virtualCamera.Follow = gameObjectToFollow.transform;
//        }
//    }
}

