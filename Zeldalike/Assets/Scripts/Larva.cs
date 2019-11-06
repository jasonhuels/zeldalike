using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Larva : Enemy
{
    private Rigidbody2D myRigidbody;
    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    public Transform homePosition;

    // Start is called before the first frame update
    void Start()
    {
        currentState = EnemyState.idle;
        myRigidbody = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckDistance();
        Vector3 previousPos = transform.position;
        
    }

    void CheckDistance()
    {
        if(Vector3.Distance(target.position, transform.position) <= chaseRadius && Vector3.Distance(target.position, transform.position) > attackRadius)
        {
            if(currentState == EnemyState.idle || currentState == EnemyState.walk && currentState != EnemyState.stagger)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
                //myRigidbody.MovePosition(temp);
                transform.position = temp;
                ChangeState(EnemyState.walk);
                if (target.position.x < transform.position.x)
                {
                    transform.localScale = new Vector3(-0.5f, 0.5f, 0);
                }
                else
                {
                    transform.localScale = new Vector3(0.5f, 0.5f, 0);

                }
            }
            
        }
    }

    private void ChangeState(EnemyState newState)
    {
        if(currentState != newState)
        {
            currentState = newState;
        }
    }
}
