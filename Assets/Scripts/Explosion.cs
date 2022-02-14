using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    
    AudioSource audioSource;
    float timer =0f;

    private void Awake()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }
    private void Start()
    {
        audioSource.Play();
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if(timer>1f)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Building" || collision.tag == "PlayerMissle" || collision.tag == "EnemyMissle" || collision.tag == "Ship")
        {
            Destroy(collision.gameObject);
        }
    }
}
