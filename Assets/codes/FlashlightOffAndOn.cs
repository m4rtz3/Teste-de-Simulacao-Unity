using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightOffAndOn : MonoBehaviour
{
    // declarar o componente da lanterna
    public Light flashlight;

    // já declarar as intensidades tbm como variaveis
    public float onIntensity = 8f;
    public float offIntensity = 0f;

    // fazer um estado para quando está apagado ou ligado já começando como false
    private bool isOn = false;

    private void Update()
    {
        // quando pressionar F no teclado...
        if (Input.GetKeyDown(KeyCode.F))
        {
            // a lanterna já está ligada, entao se pressionou, espera-se o oposto de false, que eh true
            isOn = !isOn;

            // com os valores invertidos e não voltando ao original após o fim do if, haverá sempre a alternancia
            if (isOn)
            {
                flashlight.intensity = onIntensity;
            }
            else
            {
                flashlight.intensity = offIntensity;
            }
        }
    }
}
