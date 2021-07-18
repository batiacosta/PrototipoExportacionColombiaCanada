using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GlossaryGamePanelController : MonoBehaviour
{
    public TextMeshProUGUI[] textoBotones;
    string[] bancoPalabras = new string[] { 
        "FFV",
        "Inocuidad",
        "Empaque",
        "Trazabilidad",
        "ICA",
        "Registro exportador ICA",
        "Resolución ICA ",
        "Fito" +
        "Certificado Fitosanitario",
        "Predio"
    };
    string[] bancoPreguntas = new string[] {
        "Producto obtenido de la planta crudo sin algún procesamiento",
        "Condiciones necesarias para que un alimento ingerido no represente ningún riesgo para la salud",
        "Material que protege y conserva un producto. \nFacilita su distribución al consumidor",
        "Permite verificar el proceso de un producto desde su origen hasta las etapas de su distribución",
        "Instituto Colombiano Agropecuario",
        "Documento oficial que certifica que el exportador cumple con las normas para exportar FFV",
        "Resolución de la que se obtiene el registro del predio de producción, exportadores y plantas empacadoras",
        "Significa 'Planta' o 'Vegetal'",
        "Documento que certifica que el exportador cumple con los requerimientos técnicos y procesos productivos para exportar",
        "Finca, tierra o inmueble donde se cultiva y cosecha la Gulupa"
    };
    string palabraCorrecta = "";
    string preguntaCorrecta = "";
    string[] arregloPalabrasBotones = new string[3];
    public void MostrarJuego(int elegida)
    {
        int a;
        int b;
        
        //  Seleccionar la pregunta y su palabra correcta
        palabraCorrecta = bancoPalabras[elegida];
        //  Escoger al azar dos palabras mas del banco de preguntas
        a = SeleccionRandom(elegida, 11);
        b = SeleccionRandom(elegida, a);
        //  Hacer un arreglo con las palabras aleatorias y palabra correcta en orden aleatorio
        string[] arregloTemporal = new string[3]{ bancoPalabras[elegida], bancoPalabras[a], bancoPalabras[b] };
        //  Poner la pregunta en el panel
        //  Poner las palabras en los botones
    }

    int SeleccionRandom(int referencia1, int referencia2) {
        int x = 0;
        while (x==referencia1 || x == referencia2)
        {
            x = Random.Range(0, bancoPalabras.Length);
        }
        return x;
    }
}
