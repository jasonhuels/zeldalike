using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushBlock : MonoBehaviour
{
  ParticleSystem dustParticles;
  public string value;
  //public GameObject player = GameObject.Find("Player");
  // Start is called before the first frame update
  void Start()
  {
    //dustParticles = this.GetComponent<ParticleSystem>();
    //var em = dustParticles.emission;
    //em.enabled = false;
  }

  // Update is called once per frame
  void Update()
  {

  }

  private void OnCollisionEnter(Collision other)
  {
    Debug.Log("touching");
    if (other.gameObject.tag == "Player")
    {
      Debug.Log("touching");
    }
    else
    {
      Debug.Log("!touching");
    }
  }
}


