using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ColisionesL2 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {

        print("choco");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}
