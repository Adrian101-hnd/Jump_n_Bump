using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        
        instance.vidas--;
        HUDHandler.instance.HideLives(instance.vidas);
        if (vidas > 0) 
        {
            MusicHandler.SetMusic(instance.vidas);
            PlayerPrefs.SetInt("lives", instance.vidas);
        } 
        else
        {
            MusicHandler.SetMusic(3);
        }
        Destroy(gameObject, 0.0001f);

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

}
