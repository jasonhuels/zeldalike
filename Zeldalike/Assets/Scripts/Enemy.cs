using System;
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
    public FloatValue playerHealth;
    public AudioClip sfxClip;
    public AudioSource sfxSource;
    public ParticleSystem ps;
    public ParticleSystemRenderer psr;

  // Start is called before the first frame update
  public void Awake()
  {
    CreateEnemyDeathParticleSystem(gameObject);
    ps = gameObject.GetComponent<ParticleSystem>();
    psr = gameObject.GetComponent<ParticleSystemRenderer>();
  }
  public void Start()
  {
    dying = false;
    
  }

    // Start is called before the first frame update
    void Start()
    {
        sfxSource.clip = sfxClip;
        dying = false;
    }

  // Update is called once per frame
  public void Update()
  {
    if (dying)
    {

        transform.rotation = Quaternion.Euler(0, 0, Random.value*360);
        yield return new WaitForSeconds(1);
        //StartCoroutine(DieCo());
        sfxSource.Play();
        Destroy(this.gameObject);

      Debug.Log(ps.isPlaying);
      StartCoroutine(DieCo());
      

    }
  }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            playerHealth.RunTimeValue -= 1;
        }
    }

  

  private IEnumerator DieCo()
  {
    transform.rotation = Quaternion.Euler(0, 0, UnityEngine.Random.value * 360);
    yield return new WaitForSeconds(1);
    //StartCoroutine(DieCo());
    Destroy(this.gameObject);
  }

  public void CreateEnemyDeathParticleSystem(GameObject go)
  {
    ParticleSystem ps = go.AddComponent(typeof(ParticleSystem)) as ParticleSystem;
    ParticleSystemRenderer psr = go.GetComponent<ParticleSystemRenderer>();
    ps.Stop();
    
    psr.material = new Material(Shader.Find("Sprites/Default"));

    //general
    var m = ps.main;
    
    //set colors
    m.startColor = Color.red;
    m.startSize = 0.1f;
    m.loop = false;
    m.duration = 1f;
    m.simulationSpace = ParticleSystemSimulationSpace.World;
    m.startLifetime = 0.5f;
    m.startSpeed = 5.0f;
    m.ringBufferMode = ParticleSystemRingBufferMode.PauseUntilReplaced;
    m.cullingMode = ParticleSystemCullingMode.AlwaysSimulate;
    
   
    // startSize.constantMax = 0.1f;
    // startSize.constantMin = 0.05f;
   
   //emission
    var em = ps.emission;
    em.enabled = true;
    em.rateOverTime = 50f;

  //   //size
  //   // var sz = ps.sizeOverLifetime;
  //   // sz.enabled = true;
  //   // sz.size = new ParticleSystem.MinMaxCurve(1.0f, 0.0f);
  //   //shape
    var sh = ps.shape;
    sh.enabled = true;
    sh.shapeType = ParticleSystemShapeType.Sphere;
    sh.radius = 2;

    
  }

}
