using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

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

        WWWForm forma = new WWWForm();
        forma.AddField("datosJSON", JsonUtility.ToJson(datos_registro));
        UnityWebRequest request = UnityWebRequest.Post(/*CAMBIAR*/"http://localhost/jump-n-bump/registro.php", forma);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            string texto = request.downloadHandler.text;
            if(texto == "SD")
            {
                resultado.text = "Datos faltantes";
            }
            else if (texto == "No")
            {
                resultado.text = "Ese nombre de usuario ya existe";
            }
            else
            {
                print(texto);
                SceneManager.LoadScene("Nivel1");
            }
        }
        else
        {
            print("Error al descargar");
        }
    }
}
