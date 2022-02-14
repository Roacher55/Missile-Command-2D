using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ScoresAndLevels : MonoBehaviour
{
    public int score = 0;
    int level = 1;
    int totalAmmo;
    public Text textScore;
    [SerializeField] Text textLevel;
    [SerializeField] PlayerShoot playerShoot;
    [SerializeField] SpawnEnemyMissle spawnEnemyMissle;
    public UnityEvent nextLevelEvent;
    [SerializeField] Text textMisslePoints;
    [SerializeField] Text textBuildingPoints;
    [SerializeField]GameObject pointsAddedObject;
    [SerializeField] AudioSource audioSource;
    [SerializeField] GameObject textNoAmmo;


    private void OnEnable()
    {
        nextLevelEvent.AddListener(NextLevel);
    }

    private void OnDisable()
    {
        nextLevelEvent.RemoveListener(NextLevel);
    }

    public void NextLevel()
    {
        if (spawnEnemyMissle.enemyMissles.Count == 0 && spawnEnemyMissle.totalMissleCount ==0)
        {
            playerShoot.canShoot = true;
            textNoAmmo.SetActive(false);
            foreach (var playerGun in playerShoot.playerGuns)
            {
                totalAmmo += playerGun.ammo.Count;
                playerGun.AddAmmo();
            }
            score += level * (totalAmmo * 50 + spawnEnemyMissle.buildings.Count * 100);

            textMisslePoints.text = "Missles Points " +level + " x " + totalAmmo + " x 50";
            textBuildingPoints.text = "Buildings Points " + level + " x " + spawnEnemyMissle.buildings.Count + " x 100";
            totalAmmo = 0;
            pointsAddedObject.SetActive(true);
            StartCoroutine(Wait(3f));

            level++;
            spawnEnemyMissle.totalMissleCount = 5;
            
            textScore.text = "Score: " + score;
            textLevel.text = "Level: " + level;
            EnemyMissle.missleSpeedEnemy += 0.5f;
            int random = Random.Range(0, 2);
            if (random == 1)
                spawnEnemyMissle.spawnEnemyShipEvent.Invoke();

            audioSource.Play();
        }
    }

    private IEnumerator Wait(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        pointsAddedObject.SetActive(false);
    }
}
