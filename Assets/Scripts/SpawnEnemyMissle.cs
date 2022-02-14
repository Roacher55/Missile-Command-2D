using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpawnEnemyMissle : MonoBehaviour
{
    public List<GameObject> buildings = new List<GameObject>();
    float randomTime = 3f;
    float timer = 0f;
    [SerializeField] GameObject enemyMisslePrefab;
    public int totalMissleCount = 5;
    public List<GameObject> enemyMissles = new List<GameObject>();
    [SerializeField] GameObject enemyShip;
    public UnityEvent spawnEnemyShipEvent;
    private void OnEnable()
    {
        spawnEnemyShipEvent.AddListener(SpawnEnemyShip);
    }

    private void OnDisable()
    {
        spawnEnemyShipEvent.RemoveListener(SpawnEnemyShip);
    }
    private void Awake()
    {
        foreach (var building in GameObject.FindGameObjectsWithTag("Building"))
        {
            buildings.Add(building);
        }
    }


    private void Update()
    {
        SpawnMissle();
    }

    void SpawnMissle()
    {
        if(timer> randomTime && totalMissleCount > 0)
        {
            timer = 0f;
            randomTime = Random.Range(1f, 5f);
            enemyMissles.Add(Instantiate(enemyMisslePrefab, new Vector3(Random.Range(-12f,12f),8f,-2f), Quaternion.identity));
            totalMissleCount--;
        }
        timer += Time.deltaTime;
    }

     void SpawnEnemyShip()
    {
        int random = Random.Range(0, 2);
        int temp =12;
        if(random ==1)
        {
            temp = -12;
        }

        enemyMissles.Add(Instantiate(enemyShip, new Vector3(temp, Random.Range(1f,3f), -2), Quaternion.identity));
    }
}
