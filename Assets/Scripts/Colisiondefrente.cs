using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Colisiondefrente : MonoBehaviour
{
    /*
    [SerializeField]
    private AudioSource efectomoneda;
    */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Coleccionable"))
        {
            print("toco la moneda");
            //efectomoneda.Play();
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Ganar"))
        {
            SceneManager.LoadScene("VictoryScreen");
        }
        else if (collision.gameObject.CompareTag("Puas"))
        {

        }
        else
        {
            print("choco");
            Salud_Personaje.instance.SubtractLive();
        }
    }
}
