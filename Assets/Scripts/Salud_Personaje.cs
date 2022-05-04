using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using System.Text;

public class Salud_Personaje : MonoBehaviour
{
    public int vidas = 3;
    //System.PlayerPrefs.SetString()
    public static Salud_Personaje instance;

    private void Awake()
    {
        instance = this;
        vidas = PlayerPrefs.GetInt("lives", 3);
    }

    public void SubtractLive()
    {
        print("Subtract live called");
        instance.vidas--;
        print(instance.vidas);
        HUDHandler.instance.HideLives(instance.vidas);
        if (instance.vidas > 0) 
        {
            MusicHandler.SetMusic(instance.vidas);
            PlayerPrefs.SetInt("lives", instance.vidas);
        } 
        else
        {
            MusicHandler.SetMusic(3);
        }
        Destroy(gameObject, 0.0001f);

        Subirintentos();

        if (instance.vidas > 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            SceneManager.LoadScene("GameOver");
            
            instance.vidas = 3;
        }

        
    }

    public struct DatosIntento
    {
        public string alias;
        public int idNivel;
        public int puntuacion;
        public int vidas;

    }
    public static DatosIntento datos_intento;

    public void Subirintentos()
    {
        StartCoroutine(Subirintentos2());
    }

    private IEnumerator Subirintentos2()
    {
        string user = PlayerPrefs.GetString("alias");
        int nivel = PlayerPrefs.GetInt("level");
        int puntuacion = (int)LevelManager.instance.GetProgressPercentage();
        print("puntuacion");
        print(puntuacion);
        int vidas = PlayerPrefs.GetInt("lives");


        datos_intento.alias = user;
        datos_intento.idNivel = nivel;
        datos_intento.puntuacion = puntuacion;
        datos_intento.vidas = vidas;

        // Create the request object
        using (UnityWebRequest request = new UnityWebRequest("http://165.232.147.208/api/attempt",
            UnityWebRequest.kHttpVerbPOST))
        {



            // Encode the raw JSON data
            byte[] bytesData = Encoding.UTF8.GetBytes(JsonUtility.ToJson(datos_intento));

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
                    print(request.downloadHandler.text);

                }

            }
            else
            {
                string texto = request.downloadHandler.text;
                print(texto);
            }
        }
    }

}
