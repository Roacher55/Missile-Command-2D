using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    [SerializeField] GameObject canvasEndGame;
    [SerializeField] SpawnEnemyMissle spawnEnemyMissle;
    [SerializeField] ScoresAndLevels scoresAndLevels;
    int bestScore;
    int currentScore;
    public UnityEvent endGameEvent;
    [SerializeField] Text textCurrentScore;
    [SerializeField] Text textBestScore;
    [SerializeField] PlayerShoot playerShoot;


    private void OnEnable()
    {
        endGameEvent.AddListener(GameOver);
    }

    private void OnDisable()
    {
        endGameEvent.RemoveListener(GameOver);
    }
    void GameOver()
    {
        if(spawnEnemyMissle.buildings.Count ==0)
        { 
          Time.timeScale = 0;
          playerShoot.canShoot = false;
          canvasEndGame.SetActive(true);
          currentScore = scoresAndLevels.score;

            if (PlayerPrefs.HasKey("BestScore"))
            {
                bestScore = PlayerPrefs.GetInt("BestScore");
                if (bestScore < currentScore)
                {
                    bestScore = currentScore;
                    PlayerPrefs.SetInt("BestScore", bestScore);
                }
            }
            else
            {
                bestScore = currentScore;
                PlayerPrefs.SetInt("BestScore", bestScore);
            }
            textCurrentScore.text = "Current Score: " + currentScore;
            textBestScore.text = "Best Score: " + bestScore;
        }
    }
}
