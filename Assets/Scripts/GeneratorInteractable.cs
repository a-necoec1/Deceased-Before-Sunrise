using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeneratorInteractable : Interactable
{
    private GameController game;
    private GameObject canvas;

    void Start()
    {
        game = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        canvas = gameObject.transform.GetChild(0).gameObject;
        
    }

    void FixedUpdate()
    {
        gameObject.transform.LookAt(Camera.main.transform);
    }
    public override void Interact()
    {
        game.CollectGenerator();
        Destroy(gameObject);
    }

    public override void DisplayMessage(bool status)
    {
        canvas.SetActive(status);
    }

}
