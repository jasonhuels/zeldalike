using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class School1DoorOpen : MonoBehaviour
{
    public AudioClip sfxOpen;
    public AudioSource openSource;
    // Start is called before the first frame update
    void Start()
    {
        openSource = gameObject.GetComponent<AudioSource>();
        openSource.clip = sfxOpen;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("School1_Door_Bool") == null && GameObject.Find("School1_Door_True") == null)
        {
            openSource.Play();
            Destroy(this);
        }
    }
}
