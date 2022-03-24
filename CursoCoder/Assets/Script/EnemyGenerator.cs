using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public List<GameObject> enemies = new List<GameObject>();

    GameObject enemy;
    public int enemyQuantity;
    public int strongEnemyQuantity;
    public int strongEnemySpawned;
    public int normalEnemySpawned;
    bool strongEnemyEliminated = false;
    bool normalEnemyEliminated = false;

    float timePass;
    public float spawnCoolDown;
    bool canSpawn;
    bool canSpawnABSOLUTE;

    int enemiesCount;
    private void Awake()
    {
        FindObjectOfType<Player>().OnPlayerDeath += PlayerDead;
        canSpawnABSOLUTE = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!canSpawn)
        {
            timePass += Time.deltaTime;
        }
        if (timePass > spawnCoolDown) canSpawn = true;

        if (canSpawn && enemies.Count > 0 && canSpawnABSOLUTE)
        {
            Spawn();
            timePass = 0;
            canSpawn = false;
        }
        enemiesCount = enemies.Count;
    }

    void Spawn()
    {
        int randomEnemy = Random.Range(0, enemiesCount);
        Vector3 offset;
        offset.x = Random.Range(-10, 11);
        offset.z = Random.Range(-10, 11);
        offset.y = 0.5f;

      
            enemy = Instantiate(enemies[randomEnemy], transform.position + offset, transform.rotation);

        if (enemies[randomEnemy].gameObject.name == "Strong Enemy")
        {
            strongEnemySpawned++;
        }
        if (enemies[randomEnemy].gameObject.name == "Enemy")
        {
            normalEnemySpawned++;
        }
        if (strongEnemySpawned >= strongEnemyQuantity && !strongEnemyEliminated)
        {

            // No usé foreach xq daba error en el editor "Invalid operation collection was modified"
            for (int i = 0; i < enemies.Count; i++)
            {
                GameObject Enemy = enemies[i]; 
                if (Enemy.name == "Strong Enemy")
                {
                    enemies.Remove(Enemy);
                    strongEnemyEliminated = true;
                }
            }
        }
        if (normalEnemySpawned >= enemyQuantity && !normalEnemyEliminated)
        {

            // No usé foreach xq daba error en el editor "Invalid operation collection was modified"
            for (int i = 0; i < enemies.Count; i++)
            {
                GameObject normalEnemy = enemies[i];
                if (normalEnemy.name == "Enemy")
                {
                    enemies.Remove(normalEnemy);
                    normalEnemyEliminated = true;
                }
            }
        }
    }
    void PlayerDead()
    {
        canSpawnABSOLUTE = false;
    }
    public void DisableGenerator()
    {
        gameObject.SetActive(false);
    }
}
