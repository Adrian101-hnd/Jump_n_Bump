using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using System.Text;

public class Registro : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_InputField username;
    public TMP_InputField name;
    public TMP_InputField surname;
    public TMP_InputField country;
    public TMP_InputField birthday;
    public TMP_InputField password;
    public TMP_InputField gender;

    public TextMeshProUGUI resultado;


    public struct DatosRegistro
    {
        public string alias;
        public string fechaNacimiento;
        public string nombre;
        public string apellido;
        public string genero;
        public string nacionalidad;
        public string password;


    }

    public static DatosRegistro datos_registro;


    public void RegistrarDatos()
    {
        StartCoroutine(SubirDatos_Registro());
    }

    private IEnumerator SubirDatos_Registro()
    {
        string alias = username.text;
        string nombre = name.text;
        string apellido = surname.text;
        string pais = country.text;
        string cumple = birthday.text;
        string contrasenia = password.text;
        string genero = gender.text;

        datos_registro.alias = alias;
        datos_registro.fechaNacimiento = cumple;
        datos_registro.nombre = nombre;
        datos_registro.apellido = apellido;
        datos_registro.genero = genero;
        datos_registro.nacionalidad = pais;
        datos_registro.password = contrasenia;

        // Create the request object
        using (UnityWebRequest request = new UnityWebRequest("http://165.232.147.208:4000/api/register",
            UnityWebRequest.kHttpVerbPOST))
        {

            // Encode the raw JSON data
            byte[] bytesData = Encoding.UTF8.GetBytes(JsonUtility.ToJson(datos_registro));

            // Attach data to the request
            UploadHandlerRaw uH = new UploadHandlerRaw(bytesData);
            uH.contentType = "application/json";
            request.uploadHandler = uH;
            request.downloadHandler = new DownloadHandlerBuffer();

            yield return request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.Success)
            {
                string texto = request.downloadHandler.text;

                if (texto == "OK")
                {
                    print(texto);
                    PlayerPrefs.SetString("alias", alias);
                    SceneManager.LoadScene("MenuInicio");
                }
            }
            else
            {
                string texto = request.downloadHandler.text;

                if (texto == "UndefinedFieldError")
                {
                    resultado.text = "Datos faltantes";
                }
                else if (texto == "SequelizeUniqueConstraintError")
                {
                    resultado.text = "Ese nombre de usuario ya existe";
                }
                else
                {
                    resultado.text = "Error de conexion";
                }
            }
        }
    }
}
