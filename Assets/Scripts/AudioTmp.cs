using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTmp : MonoBehaviour {

    static AudioTmp tmp = null;
    public static bool soundTmp, musicTmp;

    private void Awake()
    {
        if (tmp != null)
        {
            Destroy(gameObject);
        }
        else
        {
            tmp = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        soundTmp = true;
        musicTmp = true;
    }

    private void Update()
    {
        soundTmp = SpriteManager.soundOn;
        musicTmp = SpriteManager.musicOn;
    }
}
