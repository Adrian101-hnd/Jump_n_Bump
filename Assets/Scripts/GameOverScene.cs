using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScene : MonoBehaviour
{
    public void TryAgain()
    {
        int level = PlayerPrefs.GetInt("level");
        string sceneLevelName = "Nivel" + level.ToString();
        PlayerPrefs.SetInt("lives", 3);
        SceneManager.LoadScene(sceneLevelName);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MenuInicio");
    }
}
