using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class Flashlight : MonoBehaviour
{
    private bool flashLightOn = false;
    private float speed = 1f;

    [SerializeField] private new Light light;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(flashLightOn == true) {
            light.intensity = 15;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, 2))
            {
                light.transform.position = hit.point;
                Debug.DrawLine(ray.origin, hit.point);
            }
        }
        else
        {
            light.intensity = 0; 
        }
        
        if(Input.GetKeyDown(KeyCode.F) && flashLightOn == false){
            flashLightOn = true; 
        } else {
            if(Input.GetKeyDown(KeyCode.F) && flashLightOn == true) {
                flashLightOn = false;
            }
        }
        
        light.transform.Rotate(new Vector3(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0) * Time.deltaTime * speed);
    }
}
