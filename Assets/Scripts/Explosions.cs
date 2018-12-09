using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosions : MonoBehaviour {



    private void Start()
    {
        
        Destroy(gameObject, 1f);
    }
}
