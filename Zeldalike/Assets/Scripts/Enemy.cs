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

  // Start is called before the first frame update
  void Start()
  {
    dying = false;
    //SphereCollider sc = gameObject.AddComponent(typeof(SphereCollider)) as SphereCollider;
    
  }

  // Update is called once per frame
  void Update()
  {
    if (dying)
    {
      StartCoroutine(DieCo());
    }
  }

  private IEnumerator DieCo()
  {
    transform.rotation = Quaternion.Euler(0, 0, Random.value * 360);
    yield return new WaitForSeconds(1);
    //StartCoroutine(DieCo());
    Destroy(this.gameObject);
  }

  public ParticleSystem CreateEnemyDeathParticleSystem(GameObject go)
  {
    ParticleSystem ps = go.AddComponent(typeof(ParticleSystem)) as ParticleSystem;

    //general
    var main = ps.main;
    
    //set colors
    var startColor = main.startColor;
    startColor.colorMax = Color.red;
    startColor.colorMin = Color.black;
    main.startColor = startColor;

    main.duration = 0.5f;
    main.startLifetime = 0.5f;
    main.startSpeed = 5.0f;
    
    var startSize = main.startSize;
    startSize.constantMax = 0.1f;
    startSize.constantMin = 0.05f;
   
   //emission
    var em = ps.emission;
    em.enabled = true;
    em.rateOverTime = 50f;

    //size
    var sz = ps.sizeOverLifetime;
    sz.enabled = true;
    AnimationCurve curve = new AnimationCurve();
    curve.AddKey(1.0f, 0.0f);
    curve.AddKey(0.0f, 1.0f); 

    //shape
    var sh = ps.shape;
    sh.enabled = true;
    sh.shapeType = ParticleSystemShapeType.Sphere;
    sh.radius = 1;

    

    return ps;
  }
