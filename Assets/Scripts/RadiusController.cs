using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadiusController : MonoBehaviour
{
    private CapsuleCollider myCollider;
    private ParticleSystem carRadius;
    private EnemySpawner spawner;

    void Start()
    {
        myCollider = gameObject.GetComponent<CapsuleCollider>();
        carRadius = gameObject.GetComponent<ParticleSystem>();
        spawner = GameObject.FindGameObjectWithTag("EnemySpawner").GetComponent<EnemySpawner>();
    }
    
    void FixedUpdate()
    {
        var carRing = carRadius.shape;
        carRing.enabled = true;
        myCollider.radius = carRing.radius / (25.0f/3.0f);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Enemy Died");
            spawner.EnemyDied();
        }
    }
}
