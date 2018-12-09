using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	


	// Update is called once per frame
	void Update () {
        TouchControlls();
        //StandLoneControlls();
    }

    void StandLoneControlls()
    {
        if (Input.anyKeyDown)
        {
            FlipPlayer();
        }
    }

    void TouchControlls()
    {
        for (int i = 0; i < Input.touchCount; ++i)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
                FlipPlayer();
            }
        }
    }

    void FlipPlayer()
    {
        if (transform.rotation.z == 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 180);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

}
