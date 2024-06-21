using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;


public class EnemyManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public string[] playerNames;
    public Transform[] spawnPoints;
    public List<GameObject> enemies;
    public string killCondition = "archer";

    private void Start()
    {
        SpawnEnemies();
       
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
            SpawnEnemy();
           
        if (Input.GetKeyDown(KeyCode.K))
            KillRandomEnemy();

        if(Input.GetKeyDown(KeyCode.L))
            KillSpecificEnemy(killCondition);

        if(Input.GetKeyDown(KeyCode.J))
            KillAllEnemies();
    }

    /// <summary>
    /// Spawns a Single enemy
    /// </summary>
    private void SpawnEnemy()
    {
        int rndEnemy = Random.Range(0, enemyPrefabs.Length);
        int rndSpawn = Random.Range(0, spawnPoints.Length);
        GameObject enemy = Instantiate(enemyPrefabs[rndEnemy], spawnPoints[rndSpawn].position, spawnPoints[rndSpawn].rotation);
        enemies.Add(enemy);
        print("Enemy Count is: " + GetEnemyCount());
        //GameObject enemy1 = Instantiate(enemyPrefab, spawnPoints[0].position, spawnPoints[0].rotation);

    }
    /// <summary>
    /// Spawns an enemy based on spawn points length
    /// </summary>
    private void SpawnEnemies ()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            SpawnEnemy();
        }

        
    }
    /// <summary>
    /// Gets amount of enemies in our scene
    /// </summary>
    /// <returns>the amount of enemies</returns>
    private int GetEnemyCount()
    {
        return enemies.Count;
    }
    /// <summary>
    /// kills a enemy
    /// </summary>
    /// <param name="_enemy"></param>
    private void KillEnemy(GameObject _enemy)
    {
        if (GetEnemyCount() == 0)
            return;

        Destroy(_enemy);
        enemies.Remove(_enemy);
        print("Enemy Count is: " + GetEnemyCount());
    }
    /// <summary>
    /// kills a random enemy
    /// </summary>
    private void KillRandomEnemy()
    {
        if (GetEnemyCount() == 0)
            return;
        int rnd = Random.Range(0, GetEnemyCount());
        KillEnemy(enemies[rnd]);
    }
    /// <summary>
    /// kills a specific enemy
    /// </summary>
    /// <param name="_condition">the condition of the enemy we want to kill</param>
    private void KillSpecificEnemy(string _condition)
    {
        if (GetEnemyCount() == 0)
            return;

        for(int i = 0; i < enemies.Count; i++)
        {
            if (enemies[i].name.Contains(_condition))
                KillEnemy(enemies[i]);
        }
    }
    /// <summary>
    /// kills all enemies in enemies list
    /// </summary>
    private void KillAllEnemies()
    {
        if (GetEnemyCount() == 0)
            return;

       
        for(int i = enemies.Count - 1; i >= 0; i--)
        {
            KillEnemy(enemies[i]);
        }

    }

    #region Examples 
    private void RandomFun()
    {

        int rnd = Random.Range(0, 10);
        print(rnd);

        print(playerNames[Random.Range(0, playerNames.Length)]);

    }

    private void LoopFun()
    {
        for (int i = 0; i < playerNames.Length; i++)
        {
            print("Player" + (i+1) + " name is: " + playerNames[i]);
        }
    }


    private void ArrayFun()
    {
        print(playerNames[0]);
        print(playerNames.Length);
        playerNames[0] = "Nobody";
        print("Player 1 name is: " + playerNames[0]);
        print("Player 2 name is: " + playerNames[1]);
        print("Player 3 name is: " + playerNames[2]);
        print("Player 4 name is: " + playerNames[3]);
        

    }

    #endregion
}
