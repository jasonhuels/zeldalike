using System.Collections;
using System.Collections.Generic;
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
	private Animator animator;

	// Use this for initialization
	void Start () {
		currentState = PlayerState.walk;
		animator = GetComponent<Animator>();
		myRigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		change = Vector3.zero;
		change.x = Input.GetAxis("Horizontal");
		change.y = Input.GetAxis("Vertical");
		if(Input.GetButtonDown("attack") && currentState != PlayerState.attack)
		{
			StartCoroutine(AttackCo());
		}
		else if(currentState == PlayerState.walk)
		{
			UpdateAnimationAndMove();
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
        }
	}

	void MoveCharacter()
	{
		myRigidbody.MovePosition(transform.position + change * speed * Time.deltaTime);
	}
}
