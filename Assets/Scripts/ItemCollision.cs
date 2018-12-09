using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollision : MonoBehaviour {

    public Spawner spawner;
    public GameObject[] explosions;
    public float minTimeBtwSpawn;
    public int scoreValue = 5;
    public int bombScoreValue = 10;
    private GameController game;

    private Shake shake;

    

    private void Start()
    {

        shake = GameObject.FindGameObjectWithTag("Shake").GetComponent<Shake>();
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        GameObject spawnerObject = GameObject.FindWithTag("Spawner");

        if (gameControllerObject != null)
        {
            game = gameControllerObject.GetComponent<GameController>();
        }
        else if (gameControllerObject)
        {
            Debug.Log("gameController script is not found!");
        }

        

        if (spawnerObject != null)
        {
            spawner = spawnerObject.GetComponent<Spawner>();
        }
        else if (spawnerObject)
        {
            Debug.Log("spawner script is not found!");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Red" && gameObject.tag == "Bomb")
        {
            float tmp = spawner.maxTimeBtwSpawn;
            Destroy(gameObject);
            tmp -= 0.2f;
            if (tmp < minTimeBtwSpawn)
            {
                spawner.maxTimeBtwSpawn = minTimeBtwSpawn;
            }
            else if (tmp > minTimeBtwSpawn)
            {
                spawner.maxTimeBtwSpawn = tmp;
            }
            //instatiate the bomb explosion
            Instantiate(explosions[0], transform.position, Quaternion.identity);
            shake.camShake();
            FindObjectOfType<AudioManager>().Play("BombExplosion");
            game.UpdateScore(bombScoreValue);
        }
        if(other.tag == "BoxInStack" && gameObject.tag == "Bomb")
        {
            //Instantiate bomb explosion
            FindObjectOfType<AudioManager>().Play("BombExplosion");
            FindObjectOfType<AudioManager>().Play("GameOver");
            Instantiate(explosions[0], transform.position, Quaternion.identity);
            shake.camShake();
            Destroy(gameObject);
            game.GameOver();
        }
        if(other.tag == "Red" && gameObject.tag == "Box")
        {
            Destroy(gameObject);
            //instantiate box exlosion 
            FindObjectOfType<AudioManager>().Play("BoxExplosion");
            FindObjectOfType<AudioManager>().Play("GameOver");
            Instantiate(explosions[1], transform.position, Quaternion.identity);
            shake.camShake();
            game.GameOver();
        }
        if(other.tag == "BoxInStack" && gameObject.tag == "Box")
        {
            gameObject.transform.SetParent(GameController.stackHolder);
            gameObject.tag = "BoxInStack";
            //instantiate box collision explosion
            FindObjectOfType<AudioManager>().Play("BoxExplosion");
            shake.camShake();
            Instantiate(explosions[2], transform.position, Quaternion.identity);
        }
       
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Finish" && gameObject.tag == "BoxInStack")
        {
            foreach(Transform child in GameController.stackHolder)
            {
                GameObject.Destroy(child.gameObject);
            }
            float currentSpeed;
            game.UpdateScore(scoreValue);
            game.AddLevel();
            currentSpeed = Mathf.Log(GameController.level, 2f)*10 + MoveObject.speed;
            if (currentSpeed >= 500) {
                MoveObject.speed = 500.0f;
            }
            else if (currentSpeed < 500)
            {
                MoveObject.speed = currentSpeed;
            }
            //Instantiate box explosion

            FindObjectOfType<AudioManager>().Play("BoxExplosion");
            Instantiate(explosions[1], transform.position, Quaternion.identity);
            shake.camShake();
            game.UpdateLevel();
            
            
           
        }
    }

}
