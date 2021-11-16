using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject GameOverText;
    [SerializeField] private GameObject GameOverScreen;
    [SerializeField] private GameObject GameOverButton;
    [SerializeField] private GameObject QuitButton;

    [SerializeField] private GameObject WinText;
    [SerializeField] private GameObject WinButton;
    [SerializeField] private GameObject WinScreen;

    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private GameObject pauseButton;

    [SerializeField] private TextMeshProUGUI timerText;

    private string prefix = "Time: ";
    private ParticleSystem carRing;
    public int timer;
    public int numGenerators;
    public int numInventory;
    public int numUsed;
    private TaskManager tm;
    private bool generatorUsed = false;
    private FirstPersonController player;
    void Start()
    {
        numGenerators = 0;
        numUsed = 0;
        tm = GameObject.FindObjectOfType<TaskManager>();
        carRing = GameObject.FindGameObjectsWithTag("Car")[2].GetComponent<ParticleSystem>();
        timer = 0;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>();
    }

    void FixedUpdate()
    {
        timer = (int) Time.realtimeSinceStartup;
        UpdateTimeText();
        var carRadius = carRing.shape;
        carRadius.enabled = true;
        if (generatorUsed)
        {
            carRadius.radius += 5;
            generatorUsed = false;
        }

        if(numUsed == 6){
            GameWin();
        }
        
        if (timer >= 300)
        {
            GameOver();
        }
    }

    public void CollectGenerator()
    {
        numGenerators++;
        tm.UpdateGeneratorsCollected(numGenerators);
        numInventory++;
        tm.UpdateInventory(numInventory);
    }

    public void UseGenerator()
    {
        if (numGenerators > 0)
        {
            numUsed++;
            tm.UpdateGeneratorsUsed(numUsed);
            numGenerators = numGenerators - 1;
            generatorUsed = true;
            numInventory = numInventory - 1;
            tm.UpdateInventory(numInventory);
        }
        
    }

    private void UpdateTimeText()
    {
        timerText.SetText(prefix + timer);
    }

    public void GameOver()
    {
        Debug.Log("Game Over!");
        GameOverText.SetActive(true);
        GameOverScreen.SetActive(true);
        GameOverButton.SetActive(true);
        QuitButton.SetActive(true);
        Time.timeScale = 0;
    }

    public void GameWin()
    {
        WinScreen.SetActive(true);
        WinButton.SetActive(true);
        WinText.SetActive(true);
        QuitButton.SetActive(true);
        Time.timeScale = 0;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseScreen.SetActive(true);
        pauseButton.SetActive(false);
        player.paused = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
        pauseButton.SetActive(true);
        player.m_MouseLook.SetCursorLock(true);
        player.paused = false;
    }
}
