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
    }
}
