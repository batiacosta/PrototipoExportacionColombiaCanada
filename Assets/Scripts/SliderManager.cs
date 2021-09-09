using System.Collections;
using System.Collections.Generic;
using UnityEngine;using UnityEngine.UI;

public class SliderManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider slider;
    public Image fillArea;
    public Sprite[] colores;
    public int valor = 0;
    public void addingValue() {
        valor= valor+2;
        Debug.Log("Estoy sumando en Slider");
        if (valor <= 16) {
            slider.value = valor;
            fillArea.sprite = colores[0];
        }
        else if (15 <= valor && valor < 20)
        {
            slider.value = 15;
            //  color naranja
            fillArea.sprite = colores[1];
        }
        else if (valor > 20)
        {
            slider.value = 15;
            //  color rojo
            fillArea.sprite = colores[2];
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
