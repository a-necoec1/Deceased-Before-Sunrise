using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;

    IEnumerator Load(int level)
    {
        transition.SetTrigger("start");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(level);
    }

    public void LoadGame()
    {
        StartCoroutine(Load(1));
    }
    
    public void LoadMain()
    {
        StartCoroutine(Load(0));
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
