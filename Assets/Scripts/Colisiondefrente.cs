using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Colisiondefrente : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {

        print("choco");
        SceneManager.LoadScene("Nivel1");

    }
}
