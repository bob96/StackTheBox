using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuConntroller : MonoBehaviour {

    private int levelToLoad;
    public GameObject startSound;

    public void FadeToLevel(int levelIndex)
    {
        levelToLoad = levelIndex;
        SceneManager.LoadScene(levelToLoad);
    }

    public void StartSound()
    {
        Instantiate(startSound, transform.position, Quaternion.identity);
    }


    public void Quit()
    {
        Application.Quit();
    }
}
