using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    idle,
    walk,
    attack,
    stagger
}

public class Enemy : MonoBehaviour
{
    public EnemyState currentState;
    public int health;
    public string enemyName;
    public int baseAttack;
    public float moveSpeed;
    public bool dying;
    public AudioClip sfxClip;
    public AudioSource sfxSource;
    
    // Start is called before the first frame update
    void Start()
    {
        sfxSource.clip = sfxClip;
        dying = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(dying)
        {
            StartCoroutine(DieCo());
        }
    }

    private IEnumerator DieCo()
    {
        transform.rotation = Quaternion.Euler(0, 0, Random.value*360);
        yield return new WaitForSeconds(1);
        //StartCoroutine(DieCo());
        sfxSource.Play();
        Destroy(this.gameObject);
    }
}
