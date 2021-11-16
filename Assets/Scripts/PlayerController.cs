using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Camera viewCamera;
    private GameController game;

    private Interactable i;
    private bool shouldDisplay;

    public int numGenerators;
    private bool safe;
    private GameObject car;
    private ParticleSystem carRing;
    
    
    void Start()
    {
        viewCamera = gameObject.transform.GetChild(0).gameObject.GetComponent<Camera>();
        game = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        shouldDisplay = false;
        safe = false;
        car = GameObject.FindGameObjectWithTag("Car");
        carRing = car.GetComponent<ParticleSystem>();
    }
    void FixedUpdate()
    {
        GameObject gazeObject = ObjectBeingObserved();
        Debug.Log(gazeObject);
        shouldDisplay = false;
        if (gazeObject != null)
        {
            if (gazeObject.GetComponent<GeneratorInteractable>() != null)
            {
                i = gazeObject.GetComponent<GeneratorInteractable>();
                shouldDisplay = gazeObject.CompareTag("Generator");   
            }

            else if (gazeObject.GetComponent<CarInteractable>() != null)
            {
                i = gazeObject.GetComponent<CarInteractable>();
                shouldDisplay = gazeObject.CompareTag("Car");
            }
        }

        if (i != null)
            i.DisplayMessage(shouldDisplay);
        
        // Key Input E for Generator Interaction
        if (Input.GetKeyDown(KeyCode.E) && gazeObject.CompareTag("Generator"))
            
        {
            game.CollectGenerator();
            Destroy(gazeObject);
            
        }
        // Key Input E for Car Interaction
        if (Input.GetKeyDown(KeyCode.E) && gazeObject.CompareTag("Car"))
            
        {
            game.UseGenerator();
        }

       

        safe = (transform.position - car.transform.position).magnitude < carRing.shape.radius + 10;
    }

   
    public GameObject ObjectBeingObserved()
    {
        GameObject objHit;
        Ray gazeRay = new Ray(viewCamera.transform.position, viewCamera.transform.rotation * Vector3.forward);
        RaycastHit hit;
        if (Physics.Raycast(gazeRay, out hit, Mathf.Infinity))
        {
            hit.transform.SendMessage("GazingUpon", SendMessageOptions.DontRequireReceiver);
            objHit = hit.transform.gameObject;
            return objHit;
        }
        return null;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            game.GameOver();
        }
    }
    
    public bool IsSafe()
    {
        return safe;
    }
}
