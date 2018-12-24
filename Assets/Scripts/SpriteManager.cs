using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine;

public class SpriteManager : MonoBehaviour {

    //private
    private Image image;
    //public
    public Sprite spriteOn;
    public AudioMixer mixer;
    public static bool soundOn;
    public static bool musicOn;
    public Sprite spriteOff;

    private void Start()
    {
        soundOn = AudioTmp.soundTmp;
        musicOn = AudioTmp.musicTmp;
        image = GetComponent<Image>();
        SetSprites();
    }

    private void SetSprites()
    {
        if (gameObject.tag == "Music")
        {
            if (musicOn)
                image.sprite = spriteOn;
            else
                image.sprite = spriteOff;
        }
        else if(gameObject.tag == "Sounds")
        {
            if (soundOn)
                image.sprite = spriteOn;
            else
                image.sprite = spriteOff;
        }
    }

    public void ChangeSprite()
    {
        if(gameObject.tag == "Music")
        {
            if (musicOn)
            {
                musicOn = false;
            }
            else
            {
               
                musicOn = true;
            }
        }
        else if(gameObject.tag == "Sounds")
        {
            if (soundOn)
            {
               
                soundOn = false;
            }
            else
            {
               
                soundOn = true;
            }
        }
    }

    private void Update()
    {
        SetSprites();
    }
}
