using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarInteractable : Interactable
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
        canvas.transform.LookAt(Camera.main.transform);
    }
    
    public override void Interact()
    {
        game.UseGenerator();
    }

    public override void DisplayMessage(bool status)
    { 
        canvas.SetActive(status);
    }
}
