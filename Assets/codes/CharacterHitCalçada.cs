using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHitCalçada : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.parent != null)
        {
            string parentName = collision.transform.parent.name;
            
            if (parentName == "Calcada")
            {
                // React to collision with "Calcadas" parent
                Debug.Log("Talvez não seja uma boa ideia sair da rua...");
            }
            else if (parentName == "Muro Normal")
            {
                // React to collision with "Muro Normal" parent
                Debug.Log("Essa parte da rua está fechada, que estranho.");
            }
        }
    }
}
