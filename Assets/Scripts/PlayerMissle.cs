using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMissle : Missle
{
    public GameObject destinationVisualPoint;
    public static float missleSpeedPlayer = 5f;
    void Start()
    {
        speed = missleSpeedPlayer;
        Rotate();
    }

    void Update()
    {
        Move();
        MovePointDestroy();
    }

    private void OnDestroy()
    {
        Destroy(destinationVisualPoint.gameObject);
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Explosion" || collision.tag == "Ship" ||collision.tag == "EnemyMissle")
        {
            Instantiate(explosion, transform.position, transform.rotation);
        }
    }

}