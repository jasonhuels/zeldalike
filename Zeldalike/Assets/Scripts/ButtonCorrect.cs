using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCorrect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("You are the best coder ever!!");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Pushable")
        {
            Debug.Log("You are the best coder ever!!");
        }
    }
}
