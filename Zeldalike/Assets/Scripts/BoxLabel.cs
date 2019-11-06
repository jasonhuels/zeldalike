using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxLabel : MonoBehaviour
{

    public GameObject dialogBox;
    public Text dialogText;
    public string dialog;
    public GameObject player;
    float dist;

    // Start is called before the first frame update
    void Start()
    {
        dialogBox.SetActive(false);
        player = GameObject.Find("Player");
    }

    void LateUpdate()
    {
        dist = Vector3.Distance(gameObject.transform.position, player.transform.position);
        Debug.Log(dist);
        if (dist > 4)
        {
            dialogBox.SetActive(false);
        } else if (gameObject.GetComponent<FixedJoint2D>().connectedBody.name == "Player")
        {
            if (!dialogBox.activeInHierarchy)
            {
                dialogBox.SetActive(true);
                dialogText.text = dialog;
            }
        } 

    }

    //private void OnJointBreak2D(Joint2D joint)
    //{
    //    Debug.Log("broken");
    //    dialogBox.SetActive(false);
    //}
}
