using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour {

    public static float speed;
    private GameController game;
    public float minSpeed;
    [HideInInspector] public Rigidbody2D rb;

    private void Awake()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");

        if (gameControllerObject != null)
        {
            game = gameControllerObject.GetComponent<GameController>();
        }
        else if (gameControllerObject)
        {
            Debug.Log("gameController script is not found!");
        }
    }

    private void Start()
    {
        if(MoveObject.speed<= minSpeed)
        {
            speed = minSpeed;
        }
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate () {

        if (rb.position.x == 0) return;

        if(gameObject.tag != "BoxInStack")
            rb.velocity = new Vector2(-(rb.position.x) / Mathf.Abs(rb.position.x) * Time.deltaTime * speed, 0f);
        else if (gameObject.tag == "BoxInStack")
        {
            rb.velocity = Vector2.zero;  
        }
	}


}
