using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Linq;
using System.Security.Cryptography;

public class GlossaryGamePanelController : MonoBehaviour
{
    public TextMeshProUGUI[] textoBotones;
    public TextMeshProUGUI textoPregunta;
    public string[] bancoPalabras = new string[] { 
        "FFV",
        "Inocuidad",
        "Empaque",
        "Trazabilidad",
        "ICA",
        "Registro exportador ICA",
        "Resolución ICA ",
        "Fito",
        "Certificado Fitosanitario",
        "Predio"
    };
    public string[] bancoPreguntas = new string[] {
        "Producto obtenido de la planta crudo sin algún procesamiento",
        "Condiciones necesarias para que un alimento ingerido no represente ning?n riesgo para la salud",
        "Material que protege y conserva un producto. \nFacilita su distribuci?n al consumidor",
        "Permite verificar el proceso de un producto desde su origen hasta las etapas de su distribución",
        "Instituto Colombiano Agropecuario",
        "Documento oficial que certifica que el exportador cumple con las normas para exportar FFV",
        "Resoluci?n de la que se obtiene el registro del predio de producci?n, exportadores y plantas empacadoras",
        "Significa 'Planta' o 'Vegetal'",
        "Documento que certifica que el exportador cumple con los requerimientos t?cnicos y procesos productivos para exportar",
        "Finca, tierra o inmueble donde se cultiva y cosecha la Gulupa"
    };
    public string palabraCorrecta = "";
    string preguntaCorrecta = "";
    string[] arregloPalabrasBotones = new string[3];
    public void MostrarJuego(int elegida)
    {
        int a;
        int b;
    
        //  Seleccionar la pregunta y su palabra correcta
        palabraCorrecta = bancoPalabras[elegida];
        preguntaCorrecta = bancoPreguntas[elegida];
        //  Escoger al azar dos palabras mas del banco de preguntas
        a = SeleccionRandom(elegida, 11);
        b = SeleccionRandom(elegida, a);
        //  Hacer un arreglo con las palabras aleatorias y palabra correcta en orden aleatorio
        string[] arregloTemporal = new string[3]{ bancoPalabras[elegida], bancoPalabras[a], bancoPalabras[b] };
        int[] arr = { a, b, elegida };
        System.Random random = new System.Random();
        arr = arr.OrderBy(x => random.Next()).ToArray();
        for (int x = 0; x < arr.Length; x++)
        {
            arregloPalabrasBotones[x] = bancoPalabras[arr[x]];
        }
        //  Poner la pregunta en el panel
        PonerPregunta();
        //  Poner las palabras en los botones
        PonerRespuestasBotones();
    }

    int SeleccionRandom(int referencia1, int referencia2) {
        int x = 0;
        while (x==referencia1 || x == referencia2)
        {
            x = UnityEngine.Random.Range(0, bancoPalabras.Length);
        }
        return x;
    }
    void PonerPregunta()
    {
        textoPregunta.text = preguntaCorrecta;
    }
    void PonerRespuestasBotones()
    {
        for(int i = 0; i < arregloPalabrasBotones.Length; i++)
        {
            textoBotones[i].text = arregloPalabrasBotones[i];
        }
    }
}
