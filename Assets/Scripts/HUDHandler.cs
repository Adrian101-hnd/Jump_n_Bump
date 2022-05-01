using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HUDHandler : MonoBehaviour
{
    [SerializeField] private Image live1;
    [SerializeField] private Image live2;
    [SerializeField] private Image live3;

    [SerializeField] private Image progressBar;

    public static HUDHandler instance;

    // Start is called before the first frame update

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        HideLives(PlayerPrefs.GetInt("lives")); // Init on scene reload
    }

    // Update is called once per frame
    void Update()
    {
        UpdateProgressBar();
    }

    public void HideLives(int lives)
    {
        if (lives == 2)
        {
            live3.enabled = false;
        }
        else if (lives == 1)
        {
            live3.enabled = false;
            live2.enabled = false;
        }
        else if (lives == 0)
        {
            live3.enabled = false;
            live2.enabled = false;
            live1.enabled = false;
        }
    }

    private void RTSetRight(RectTransform rt, float right)
    {
        rt.offsetMax = new Vector2(-right, rt.offsetMax.y);
    }

    private void UpdateProgressBar()
    {
        float right = 100 - LevelManager.instance.GetProgressPercentage();
        RTSetRight(progressBar.GetComponent<RectTransform>(), right);
    }
}
