using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    [SerializeField] private TMP_Text genCollected;
    [SerializeField] private TMP_Text genUsed;
    
  
    
    [SerializeField] private TMP_Text PlayerInventory;
    public void UpdateGeneratorsCollected(float gens)
    {
        if (gens == 6)
        {
            genCollected.color = Color.green;
        }
        else
        {
            genCollected.color = Color.yellow;
        }
        genCollected.text = "(" + gens + "/6) Generators Collected";
    }

    public void UpdateGeneratorsUsed(float gens)
    {
        if (gens == 6)
        {
            genUsed.color = Color.green;
        }
        else
        {
            genUsed.color = Color.yellow;
        }

        genUsed.text = "(" + gens + "/6) Generators Used";
    }

    public void UpdateInventory(float inv)
        {

            PlayerInventory.text = "Inventory: " + inv + " Generators";
        }
    
}
