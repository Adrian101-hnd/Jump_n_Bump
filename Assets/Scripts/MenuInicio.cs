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
        PlayerPrefs.SetInt("level", 1);
        SceneManager.LoadScene("Nivel1");
    }

    public void PlayLevel2()
    {
        // Cargar la escena nivel 2
        PlayerPrefs.SetInt("lives", 3);
        PlayerPrefs.SetInt("level", 2);
        SceneManager.LoadScene("Nivel2");
    }

    public void PlayLevel3()
    {
        // Cargar la escena nivel 3
        PlayerPrefs.SetInt("lives", 3);
        PlayerPrefs.SetInt("level", 3);
        SceneManager.LoadScene("Nivel3");
    }

    public void PlayTutorial()
    {
        // Cargar el tutorial
        PlayerPrefs.SetInt("lives", 1);
        PlayerPrefs.SetInt("level", 0);
        SceneManager.LoadScene("Nivel0");
    }

    public void LoadCredits()
    {
        SceneManager.LoadScene("Creditos");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MenuInicio");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
