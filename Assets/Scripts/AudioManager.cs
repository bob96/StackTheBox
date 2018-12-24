using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public static AudioClip boxExplosion, boxStack, BombExplosion, click, gameOver;
    public AudioClip boxExplosionRc, boxStackRc, BombExplosionRc, clickRc, gameOverRc;
    static AudioSource audioSrc;
    static GameObject music;
    static AudioSource musicSource;

    private void Start()
    {
        music = GameObject.FindGameObjectWithTag("Music");

        musicSource = music.GetComponent<AudioSource>();

        boxExplosion = boxExplosionRc;
        boxStack = boxStackRc;
        BombExplosion = BombExplosionRc;
        click = clickRc;
        gameOver = gameOverRc;

        audioSrc = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {
        if (SpriteManager.soundOn)
        {
            switch (clip)
            {
                case "BoxExplosion":
                    audioSrc.PlayOneShot(boxExplosion);
                    break;
                case "BoxStack":
                    audioSrc.PlayOneShot(boxStack);
                    break;
                case "BombExplosion":
                    audioSrc.PlayOneShot(BombExplosion);
                    break;
                case "Click":
                    audioSrc.PlayOneShot(click);
                    break;
                case "GameOver":
                    audioSrc.PlayOneShot(gameOver);
                    break;
            }
        }
        else
            return;
       
    }

    private void Update()
    {
        PlayMusic();
    }

    public static void PlayMusic()
    {
        if (SpriteManager.musicOn)
        {
            if(musicSource.volume == 0)
            {
                musicSource.volume = 0.5f;
            }
        }
        else
            musicSource.volume = 0;
    }
}
