using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class Iniciosesion : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_InputField username;
    public TMP_InputField password;
    public TextMeshProUGUI resultado;
    public struct DatosInicio
    {
        public string alias;
        public string password;
        
    }
    public static DatosInicio datos_inicio;

    public void VerDatos()
    {
        StartCoroutine(SubirDatos_Inicio());
    }

    private IEnumerator SubirDatos_Inicio()
    {
        string user = username.text;
        string contrasenia = password.text;

        datos_inicio.alias = user;
        datos_inicio.password = contrasenia;

        WWWForm forma = new WWWForm();
        forma.AddField("datosJSON", JsonUtility.ToJson(datos_inicio));
        UnityWebRequest request = UnityWebRequest.Post(/*CAMBIAR*/"http://localhost/jump-n-bump/iniciosesion.php", forma);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            string texto = request.downloadHandler.text;
            if (texto == "No")
            {
                resultado.text = "El alias o la contraseña son incorrectas";
                print("El alias o la contraseña son incorrectas");
            }
            else {
                print(request.downloadHandler.text);
                SceneManager.LoadScene("MenuInicio"); }
            
        }
        else
        {
            print("Error al descargar");
        }
    }
}
