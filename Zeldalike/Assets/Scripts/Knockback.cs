﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
  public float thrust;
  public float knockTime;

  ParticleSystem ps;

  void OnTriggerEnter2D(Collider2D other)
  {
    if (other.gameObject.CompareTag("Enemy"))
    {

      Rigidbody2D enemy = other.GetComponent<Rigidbody2D>();
      ps = other.GetComponent<ParticleSystem>();
      if (enemy != null)
      {
        ps.Play();
        other.GetComponent<Enemy>().dying = true;
        other.GetComponent<Enemy>().sfxSource.Play();
        //enemy.GetComponent<Enemy>().currentState = EnemyState.stagger;
        enemy.isKinematic = false;
        Vector2 difference = enemy.transform.position - transform.position;
        difference = difference.normalized * thrust;
        enemy.AddForce(difference, ForceMode2D.Impulse);
        enemy.constraints = RigidbodyConstraints2D.None;
        other.transform.rotation = Quaternion.Euler(10, 10, 100);

        StartCoroutine(KnockCo(enemy));
      }

    }
  }

  private IEnumerator KnockCo(Rigidbody2D enemy)
  {
    if (enemy != null)
    {
      yield return new WaitForSeconds(knockTime);
      enemy.velocity = Vector2.zero;
      enemy.isKinematic = true;
      enemy.GetComponent<Enemy>().currentState = EnemyState.idle;
    }
  }
}
