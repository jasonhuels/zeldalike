using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushBlock : MonoBehaviour
{
  public string value;
  public ParticleSystem ps;
  public ParticleSystemRenderer psr;
  //public GameObject player = GameObject.Find("Player");
  // Start is called before the first frame update
  void Awake()
  {
    CreateBoxDustCloudParticleSystem(gameObject);
    ps = gameObject.GetComponent<ParticleSystem>();
    psr = gameObject.GetComponent<ParticleSystemRenderer>();
    ps.Stop();

  }
  void Start()
  {
        Destroy(GetComponent<FixedJoint2D>());
        
  }

  // Update is called once per frame
  void Update()
  {

  }

  public void CreateBoxDustCloudParticleSystem(GameObject go)
  {
    ParticleSystem ps = go.AddComponent(typeof(ParticleSystem)) as ParticleSystem;
    ParticleSystemRenderer psr = go.GetComponent<ParticleSystemRenderer>();
    ps.Stop();

    psr.material = new Material(Shader.Find("Default/ParticleMaterial"));

    //general
    var m = ps.main;

    //set colors
    m.startColor = Color.grey;
    m.startSize = 2f;
    m.loop = false;
    m.duration = 0.5f;
    m.simulationSpace = ParticleSystemSimulationSpace.World;
    m.startLifetime = 0.5f;
    m.startSpeed = 1.0f;
    m.ringBufferMode = ParticleSystemRingBufferMode.PauseUntilReplaced;
    m.cullingMode = ParticleSystemCullingMode.AlwaysSimulate;


    // startSize.constantMax = 0.1f;
    // startSize.constantMin = 0.05f;

    //emission
    var em = ps.emission;
    em.enabled = true;
    em.rateOverTime = 30f;

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


