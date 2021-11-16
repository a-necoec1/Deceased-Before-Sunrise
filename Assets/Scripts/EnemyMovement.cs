using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemyMovement
    : MonoBehaviour {
    [SerializeField] private float speed;
    [SerializeField] private float startWaitTime;
    [SerializeField] public GameObject start;
    [SerializeField] public GameObject end;
    [SerializeField] private float aggroRange;
    [SerializeField] private GameObject parent;
    private bool movingBack;
    private float waitTime;
    private float liveTime;
    private bool aggro;
    private GameObject player;
    private PlayerController play;
    private ParticleSystem carRing;
    private GameController game;
    private GameObject car;
    
    // Start is called before the first frame update
    private void Start()
    {
        game = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        liveTime = startWaitTime * 5;
        waitTime = startWaitTime;
        movingBack = false;
        aggro = false;
        player = GameObject.FindGameObjectWithTag("Player");
        play = player.GetComponent<PlayerController>();
        car = GameObject.FindGameObjectsWithTag("Car")[2];
        carRing = car.GetComponent<ParticleSystem>();
        

    }

    // Update is called once per frame
    private void Update() {
        aggro = (player.transform.position - transform.position).magnitude < aggroRange && !play.IsSafe();
        switch (aggro) {
            case false: {
                transform.position = Vector3.MoveTowards(transform.position,
                    movingBack ? start.transform.position : end.transform.position, speed * Time.deltaTime);
                if (waitTime <= 0) {
                    movingBack = !movingBack;
                    waitTime = startWaitTime;
                }
                else {
                    waitTime -= Time.deltaTime;
                }
                break;
            }
            case true: {
                

                if ((transform.position - player.transform.position).magnitude < 2)
                {
                    game.GameOver();
                }
                transform.position =
                                     Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
                break;
            }
        }

        if (liveTime > 0 || aggro) {
            liveTime -= Time.deltaTime;
        }
        else
        {
            var spawn = FindObjectOfType<EnemySpawner>();
            spawn.EnemyDied();
            Destroy(parent);
        }
    }

    
}