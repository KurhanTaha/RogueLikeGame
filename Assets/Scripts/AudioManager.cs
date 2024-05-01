using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource levelMusic,gameOverMusic,winMusic;
    public AudioSource[] sFX;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGameOver()
    {
        levelMusic.Stop();
        gameOverMusic.Play();
    }
    public void PlayWinMusic()
    {
        levelMusic.Stop();
        winMusic.Play();
    }

    public void SFXPlay(int sFxToPlay)
    {
        sFX[sFxToPlay].Stop();
        sFX[sFxToPlay].Play();
    }
}
