using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignRead : MonoBehaviour
{

    public GameObject dialogBox;
    public Text dialogText;
    public string dialog;
    public bool playerInRange;

    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.RightShift))
        {

            if(dialogBox.activeInHierarchy)
            {
                dialogBox.SetActive(false);
            } else
            {
                dialogBox.SetActive(true);
                dialogText.text = dialog;
            }
            
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