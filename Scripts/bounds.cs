using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class bounds : MonoBehaviour
{
    private Bounds b;

    void Start()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            b = new Bounds(new Vector3(1, 0, 0), new Vector3(3, 3, 3));
        }
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
