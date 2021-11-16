using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    private float spawnTimer;
    private bool enemySpawned;
    private List<List<Vector3>> spawnPoints;
    private int numPoints;
    private int currentPoint;
    private float startSpawn;
    // Start is called before the first frame update
    void Start() {
        enemySpawned = false;
        startSpawn = 10;
        spawnTimer = startSpawn;
        InitializeSpawnPoints();
        numPoints = spawnPoints.Count;
        currentPoint = 0;
    }

    // Update is called once per frame
    void Update() {
        if (enemySpawned) return;
        if (spawnTimer <= 0) {   
            enemySpawned = true;
            currentPoint = (currentPoint + 1) % numPoints;
            Instantiate(enemy, spawnPoints[currentPoint][0], Quaternion.identity).GetComponent<EnemyMovement>();
            var newEnemy = FindObjectOfType<EnemyMovement>();
            newEnemy.start.transform.localPosition = spawnPoints[currentPoint][1];
            newEnemy.end.transform.localPosition = spawnPoints[currentPoint][2];
            spawnTimer = startSpawn;
        }
        else {
            spawnTimer -= Time.deltaTime;
        }
    }

    private void InitializeSpawnPoints()
    {
        spawnPoints = new List<List<Vector3>>();
        var spawnPoint = new List<Vector3> {
            new Vector3(500, 0, 700),
            new Vector3(-31, 0, 0),
            new Vector3(11, 0, 0)
        };
        spawnPoints.Add(spawnPoint);
        spawnPoint = new List<Vector3> {
            new Vector3(363, 0, 687),
            new Vector3(4, 0, 22),
            new Vector3(12, 0, -85)
        };
        spawnPoints.Add(spawnPoint);
    }

    public void EnemyDied()
    {
        enemySpawned = false;
        try
        {
            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
        }
        catch
        {
            return;
        }
    }
}
