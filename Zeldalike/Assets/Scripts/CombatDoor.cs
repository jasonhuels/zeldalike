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

        if (target == null)
        {
            transform.parent.GetComponent<School2DoorOpen>().openSource.Play();
            Destroy(gameObject);
        }
    }

    private IEnumerator DeathCo()
    {
        yield return new WaitForSeconds(5);

        Destroy(gameObject);
    }

}
