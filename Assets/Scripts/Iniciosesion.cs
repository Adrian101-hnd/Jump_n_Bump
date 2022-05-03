using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using System.Text;

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

        // Create the request object
        using(UnityWebRequest request = new UnityWebRequest("http://165.232.147.208/api/login",
            UnityWebRequest.kHttpVerbPOST)){



            // Encode the raw JSON data
            byte[] bytesData = Encoding.UTF8.GetBytes(JsonUtility.ToJson(datos_inicio));

            // Attach data to the request
            UploadHandlerRaw uH = new UploadHandlerRaw(bytesData);
            uH.contentType = "application/json";
            request.uploadHandler = uH;
            request.downloadHandler = new DownloadHandlerBuffer();

            yield return request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.Success)
            {
                string texto = request.downloadHandler.text;
                if (texto == "Access granted")
                {
                    print(request.downloadHandler.text);
                    PlayerPrefs.SetString("alias", user);
                    SceneManager.LoadScene("MenuInicio");
                }

            }
            else
            {
                string texto = request.downloadHandler.text;
                if (texto == "Incorrect password" || texto == "Alias does not exist")
                {
                    resultado.text = "El alias o la contraseña son incorrectas";
                    print("El alias o la contraseña son incorrectas");
                }
                else
                {
                    print("Error al descargar");
                }
            }
        } }
}
