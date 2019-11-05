using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign2 : MonoBehaviour
{

    public GameObject dialogBox;
    public Text dialogText;
    public string dialog;
    public bool playerInRange;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    //void Update()
    //{
    //    if (playerInRange)
    //    {
    //        if (dialogBox.activeInHierarchy)
    //        {
    //            dialogBox.SetActive(false);
    //        }
    //        else
    //        {
    //            dialogBox.SetActive(true);
    //            dialogText.text = dialog;
    //        }
    //    }
    //}
   

    void Update()
    {
        if (playerInRange)
        {
            dialogBox.SetActive(true);
            dialogText.text = dialog;
        } else
        {
            dialogBox.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            Debug.Log("in range");
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            playerInRange = false;
            dialogBox.SetActive(false);
            Debug.Log("out range");
        }

    }
}