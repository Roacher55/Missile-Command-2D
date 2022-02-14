using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    float target;
    float timer;
    SpawnEnemyMissle spawnEnemyMissle;
    ScoresAndLevels scoresAndLevels;
    [SerializeField] GameObject enemyMisslePrefab;

    private void Awake()
    {
        spawnEnemyMissle = FindObjectOfType<SpawnEnemyMissle>();
        scoresAndLevels = FindObjectOfType<ScoresAndLevels>();
    }
    void Start()
    {
        timer = Random.Range(3f, 8f);
        target = -transform.position.x;
    }
     void Update()
    {
        Move();
        SpawnMissle();
    }
    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(target, transform.position.y, transform.position.z), EnemyMissle.missleSpeedEnemy * Time.deltaTime);
        if (transform.position.x == target)
            target = -target;
    }

    void SpawnMissle()
    {
        if (timer<=0)
        {
            timer = Random.Range(3f, 8f);
            spawnEnemyMissle.enemyMissles.Add(Instantiate(enemyMisslePrefab, transform.position, Quaternion.identity));
        }
        timer -= Time.deltaTime;
    }

    private void OnDestroy()
    {
        scoresAndLevels.score += 200;
        spawnEnemyMissle.enemyMissles.Remove(this.gameObject);
    }

}
