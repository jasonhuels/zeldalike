using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatDoor : MonoBehaviour
{
    //private bool openDoor;
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        //openDoor = false;
    }

    // Update is called once per frame
    void Update()
    {
        target = GameObject.FindWithTag("Enemy");
        Debug.Log(target);


        if (target == null)
        {
            Destroy(gameObject);
        }
    }
}
