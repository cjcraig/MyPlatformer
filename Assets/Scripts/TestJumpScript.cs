using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestJumpScript : MonoBehaviour
{

    SpriteRenderer renderer; 

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButton("Jump"))
        {
            renderer.material.SetColor("_Color", Color.green);
        }
        else
        {
            renderer.material.SetColor("_Color", Color.red);
        }

    }
}
