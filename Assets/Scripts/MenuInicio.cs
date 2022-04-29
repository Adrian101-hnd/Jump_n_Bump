using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicio : MonoBehaviour
{
    public void PlayLevel1()
    {
        // Cargar la escena nivel 1
        PlayerPrefs.SetInt("lives", 3);
        SceneManager.LoadScene("Nivel1");
    }

    public void PlayLevel2()
    {
        // Cargar la escena nivel 2
        PlayerPrefs.SetInt("lives", 3);
        SceneManager.LoadScene("Nivel2");
    }

    public void PlayLevel3()
    {
        // Cargar la escena nivel 3
        PlayerPrefs.SetInt("lives", 3);
        SceneManager.LoadScene("Nivel3");
    }
}
