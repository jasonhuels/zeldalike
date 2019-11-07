using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushBlock : MonoBehaviour
{
  public string value;
  //public GameObject player = GameObject.Find("Player");
  // Start is called before the first frame update
  void Start()
  {
        Destroy(GetComponent<FixedJoint2D>());
        
  }

  // Update is called once per frame
  void Update()
  {

  }
}


