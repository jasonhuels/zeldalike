using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public enum PlayerState
{
	walk,
	attack,
	interact
}

public class PlayerMovement : MonoBehaviour {
	public PlayerState currentState;
	public float speed;
	private Rigidbody2D myRigidbody;
	private Vector3 change;
	private Vector3 direction;
	private Animator animator;
    public float distance = 2f;
    public LayerMask boxMask;
    public FloatValue currentHealth;
	public AudioClip sfxSlash;
    public AudioClip sfxStep;
	public AudioSource stepSource;
    public AudioSource slashSource;
	private bool stepPlaying = false;

    GameObject box;

	// Use this for initialization
	void Start () {
		currentState = PlayerState.walk;
		animator = GetComponent<Animator>();
		myRigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(change);
		change = Vector3.zero;
		change.x = Input.GetAxis("Horizontal");
		change.y = Input.GetAxis("Vertical");
		if(Input.GetButtonDown("attack") && currentState != PlayerState.attack)
		{
            slashSource.clip = sfxSlash;
            slashSource.Play();
			StartCoroutine(AttackCo());
		}
		else if(currentState == PlayerState.walk)
		{
			UpdateAnimationAndMove();
		}

		if(!stepPlaying && (change.x != 0 || change.y != 0))
		{
            stepSource.clip = sfxStep;
            stepSource.Play();
			stepPlaying = true;
            StartCoroutine(StepCo());
		}

        RaycastHit2D hit = Physics2D.Raycast(transform.position + change , change, distance);
		
        if(hit.collider != null && hit.collider.gameObject.tag == "Pushable" && Input.GetKeyDown(KeyCode.RightShift))
		{
            box = hit.collider.gameObject;
            Destroy(box.GetComponent<FixedJoint2D>());
			box.AddComponent<FixedJoint2D>();
            box.GetComponent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();
            box.GetComponent<FixedJoint2D>().breakForce = Mathf.Infinity;
            box.GetComponent<FixedJoint2D>().enabled = true;
		}else if(Input.GetKeyUp(KeyCode.RightShift))
        {
            //box.GetComponent<FixedJoint2D>().enabled = false;
            //box.GetComponent<boxpull>().beingPushed = false;
			Destroy(box.GetComponent<FixedJoint2D>());
        }
	}

	private IEnumerator AttackCo()
	{
		animator.SetBool("attacking", true);
		currentState = PlayerState.attack;
		yield return null;
		animator.SetBool("attacking", false);
		yield return new WaitForSeconds(0.3f);
		currentState = PlayerState.walk;
	}

    private IEnumerator StepCo()
    {
        yield return new WaitForSeconds(0.4f);
        
		stepPlaying =false;
    }

	void UpdateAnimationAndMove()
	{
        if (change != Vector3.zero)
        {
            MoveCharacter();
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("moving", true);
        }
        else
        {
            animator.SetBool("moving", false);
			change.x = 0;
			change.y = 0;
        }
	}

	void MoveCharacter()
	{
		myRigidbody.MovePosition(transform.position + change * speed * Time.deltaTime);
	}



}
