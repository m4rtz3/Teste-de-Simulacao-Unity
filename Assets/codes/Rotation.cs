using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{

    public Vector2 turn;
    public float sensivityMouseY = .5f;
    public float sensivityMouseX = .5f;
    public Vector3 deltaMove;
    public float speed = 1;
    public GameObject mover;

    private bool podeMover = true;

    // Start is called before the first frame update
    public void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (!podeMover) return;
        Rotacao();
    }

    public void Rotacao()
    {
        if (!podeMover) return;

        turn.y += Input.GetAxis("Mouse Y") * sensivityMouseY; //vertical

        transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);
    }

    public void Paralisar() {
        podeMover = false;
        Rotacao();
    }

    public void sairParalisar() {
        podeMover = true;
        Rotacao();
    }
}
