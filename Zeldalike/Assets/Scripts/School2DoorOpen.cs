using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class School2DoorOpen : MonoBehaviour
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
        
    }
}
