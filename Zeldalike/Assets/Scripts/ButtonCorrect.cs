using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCorrect : MonoBehaviour
{
    public string value;
    public bool correct;
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
        if (other.gameObject.tag == "Pushable" && other.GetComponent<PushBlock>().value == value)
        {
            //Debug.Log("You are the best coder ever!!");
            //change box to blue
            other.GetComponent<SpriteRenderer>().color = Color.blue;
            //enable particle emissions
            //var em = other.GetComponent<ParticleSystem>().emission;
            //em.enabled = true;
            //snap box into trigger place
            Vector3 v3 = this.transform.position - other.transform.position;
            other.transform.position += v3;
            Destroy(other.GetComponent<FixedJoint2D>());
            Destroy(other.GetComponent<Rigidbody2D>());
            correct = true;
        }
    }
}
