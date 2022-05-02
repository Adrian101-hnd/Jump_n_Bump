using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{

    private AudioSource audioSource;
    

    public GameObject menuPausa;

    public static bool estaPausado = false;


    private void Awake()
    {
        estaPausado = false;
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
        public void Pausar()
    {
        /*
        if (estaPausado == true)
        {
            
            float pauseEndTime = Time.realtimeSinceStartup + 3;
            while (Time.realtimeSinceStartup < pauseEndTime)
            {

            }
        }
        */
        if (estaPausado)
        {
            audioSource.Play(0);
        }
        else
        {
            audioSource.Pause();
        }
  
        estaPausado = !estaPausado;
            menuPausa.SetActive(estaPausado);
            Time.timeScale = estaPausado ? 0 : 1;
        
    }

    public void salir()
    {
        Pausar();
        SceneManager.LoadScene("MenuInicio");
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pausar();
        }
    }


}
