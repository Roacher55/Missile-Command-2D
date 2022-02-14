using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missle : MonoBehaviour
{
    public Vector3 targetDestination;
    public float speed = 3f;
    [SerializeField]protected GameObject explosion;
    protected void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetDestination, speed * Time.deltaTime);
    }

    protected void Rotate()
    {
        Vector3 targetPos = targetDestination;
        Vector3 thisPos = transform.position;
        targetPos.x = targetPos.x - thisPos.x;
        targetPos.y = targetPos.y - thisPos.y;
        float angle = Mathf.Atan2(targetPos.y, targetPos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle - 90f));
    }

    protected void MovePointDestroy()
    {
        if (this.transform.position == targetDestination)
        {
            Instantiate(explosion, transform.position, transform.rotation);
        }
    }
}
