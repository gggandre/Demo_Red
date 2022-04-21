using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using System;

public class Red : MonoBehaviour
{
    //Autor Gilberto André García Gaytán
    //Este código hace la conexión a la red

    public TextMeshProUGUI resultado;


    //Los datos de entrada

    public TMP_InputField textoNombre;
    public TMP_InputField textoPuntos;

    //Recibe JSON

    public void LeerJSON()
    {
        StartCoroutine(DescargarJSON());
    }

    private IEnumerator DescargarJSON()
    {
        UnityWebRequest request = UnityWebRequest.Get("http://localhost/unity/enviaJSON.php");
        yield return request.SendWebRequest(); // Regresa, inicia la descarga

        if(request.result == UnityWebRequest.Result.Success)
        {
            string texto = request.downloadHandler.text;
            resultado.text = texto;

            //Deserializar

            datos = JsonUtility.FromJson<DatosUsuario>(texto);
            resultado.text = resultado.text + "\nNombre:" + datos.nombre + "\nPuntos:" + datos.puntos;
        }
    }


    //Estructura de los datos JSON

    public struct DatosUsuario
    {
        public string nombre;
        public int puntos;
    }
    public DatosUsuario datos;    //se va a convertir a JSON ->

    //Enviar JSON (Click)

    public void EnviarJSON()
    {
        StartCoroutine(SubirJSON());
    }

    private IEnumerator SubirJSON()
    {
        //Llena la estructura
        datos.nombre = textoNombre.text;
        datos.puntos = int.Parse(textoPuntos.text);
        print(JsonUtility.ToJson(datos)); //"{"nombre": "andré",}"

        WWWForm forma = new WWWForm();
        forma.AddField("datosJSON", JsonUtility.ToJson(datos));
        UnityWebRequest request = UnityWebRequest.Post("http://localhost/unity/recibeJSON.php", forma);
        yield return request.SendWebRequest();
        // .. después de cierto tiempo
        if (request.result == UnityWebRequest.Result.Success)
        {
            string texto = request.downloadHandler.text;
            resultado.text = texto;
        }
        else
        {
            resultado.text = "Error" + request.ToString();
        }
    }

    //Se llama con el click del botón
    public void LeerTextoPlano()
    {
        StartCoroutine(DescargarDatosRed());
    }

    private IEnumerator DescargarDatosRed()
    {
        UnityWebRequest request = UnityWebRequest.Get("http://localhost/unity/doc.txt");
        yield return request.SendWebRequest(); // Regresa, inicia la descarga
        //Esto se ejecuta después de cierto tiempo
        if (request.result == UnityWebRequest.Result.Success)
        {
            string txtResultado = request.downloadHandler.text;
            resultado.text = txtResultado;
        }
        else
        {
            resultado.text = "Error";
        }
    }





//Enviar los datos al servidor (click del botón)


public void EnviarTextoPlano()
    {
        StartCoroutine(SubirTextoPlano());
    }

    private IEnumerator SubirTextoPlano()
    {
        //Recuperar los datos
        string nombre = textoNombre.text;
        string puntos = textoPuntos.text;
        //Crear un objeto con los datos que se quieren enviar
        WWWForm forma = new WWWForm();
        forma.AddField("nombre", nombre);
        forma.AddField("puntos", puntos);

        UnityWebRequest request = UnityWebRequest.Post("http://localhost/unity/recibeTextoPlano.php", forma);
        yield return request.SendWebRequest();
        // .. después de cierto tiempo
        if (request.result == UnityWebRequest.Result.Success)
        {
            string texto = request.downloadHandler.text;
            resultado.text = texto;
        }
        else
        {
            resultado.text = "Error" + request.ToString();
        }
    }

    //Se llama con el click del botón
    

}
