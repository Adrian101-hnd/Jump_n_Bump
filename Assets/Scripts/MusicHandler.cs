using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicHandler : MonoBehaviour
{
    [SerializeField] private AudioClip optimalSong;
    [SerializeField] private AudioClip moderateLossSong;
    [SerializeField] private AudioClip severeLossSong;

    private int currentLevel;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        string currentSongName = PlayerPrefs.GetString("currentSongName", "NoSong");

        if (currentSongName == "NoSong")
        {
            currentSongName = "optimalSong";
        }

        AudioClip currentSong = optimalSong; /*= (AudioClip)this.GetType().GetField(currentSongName).GetValue(this);*/

        if (currentSongName == "optimalSong") currentSong = optimalSong;
        else if (currentSongName == "moderateLossSong") currentSong = moderateLossSong;
        else if (currentSongName == "severeLossSong") currentSong = severeLossSong;

        print(currentSongName);
        audioSource.clip = currentSong;
        audioSource.Play();
    }


    public static void SetMusic(int lives)
    {
        if (lives == 3)
        {
            PlayerPrefs.SetString("currentSongName", "optimalSong");
        }
        else if (lives == 2)
        {
            PlayerPrefs.SetString("currentSongName", "moderateLossSong");
        }
        else if (lives == 1)
        {
            PlayerPrefs.SetString("currentSongName", "severeLossSong");
        }
    }


}
