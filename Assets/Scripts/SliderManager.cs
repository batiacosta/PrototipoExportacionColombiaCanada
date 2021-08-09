using System.Collections;
using System.Collections.Generic;
using UnityEngine;using UnityEngine.UI;

public class SliderManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider slider;
    public Image fillArea;
    public int valor = 0;
    public void addingValue() {
        valor= valor+2;
        Debug.Log("Estoy sumando en Slider");
        if (valor <= 15) {
            slider.value = valor;
            fillArea.color = new Color(69, 167, 104);//45A768;
        }
        else if (15 <= valor && valor < 20)
        {
            slider.value = 15;
            //  color naranja
            fillArea.color = new Color(253, 201, 8);
        }
        else if (valor > 20)
        {
            slider.value = 15;
            //  color rojo
            fillArea.color = new Color(255, 0, 0);
        }
    }
    public void resetSliderValue()
    {
        valor = 0;
        slider.value = valor;
        //  Color verde
        fillArea.color = new Color(69, 167, 104);
    }
}
