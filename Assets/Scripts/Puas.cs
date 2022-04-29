using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Puas : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            print("Tocando espina");
            // Descontar vida
            Salud_Personaje.instance.SubtractLive();
            //HUD.instance.ActualizarVidas();
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);


            /*
            if (Salud_Personaje.instance.vidas == 0)
            {
                //Destruir personaje
                Destroy(collision.gameObject, 0.1f);

            }
            */
        }
    }
}
