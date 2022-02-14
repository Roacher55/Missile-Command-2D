using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMissle : Missle
{
    SpawnEnemyMissle spawnEnemyMissle;
    public static float missleSpeedEnemy = 1f;
    ScoresAndLevels scoresAndLevels;
    bool isDestroy = false;
    void Start()
    {
        scoresAndLevels = FindObjectOfType<ScoresAndLevels>();
        speed = missleSpeedEnemy;
        spawnEnemyMissle = FindObjectOfType<SpawnEnemyMissle>();
        var random = Random.Range(0, spawnEnemyMissle.buildings.Count - 1);
        targetDestination = spawnEnemyMissle.buildings[random].transform.position;
        Rotate();
    }

    void Update()
    {
        Move();
        MovePointDestroy();
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Building" || collision.tag == "PlayerMissle" || collision.tag == "Explosion")
        {
            Instantiate(explosion, transform.position, transform.rotation);

            if(!isDestroy)
            {
                scoresAndLevels.score += 50;
                scoresAndLevels.textScore.text = "Score: " + scoresAndLevels.score;
                spawnEnemyMissle.enemyMissles.Remove(this.gameObject);
                scoresAndLevels.nextLevelEvent.Invoke();
                isDestroy = !isDestroy;
            }
        }
    }

}
