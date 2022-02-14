using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    SpawnEnemyMissle spawnEnemyMissle;
    EndGame endGame;

    private void Awake()
    {
        spawnEnemyMissle = FindObjectOfType<SpawnEnemyMissle>();
        endGame = FindObjectOfType<EndGame>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "EnemyMissle" || collision.tag == "Explosion")
        {
            spawnEnemyMissle.buildings.Remove(this.gameObject);
            endGame.endGameEvent.Invoke();
        }
    }
  
}
