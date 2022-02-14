using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    [SerializeField] PlayerShoot playerShoot;
    public List<GameObject> ammo;
    private void Awake()
    {
        AddAmmo();
        playerShoot.playerGuns.Add(this);
    }

    public void  AddAmmo()
    {
        ammo.Clear();
        foreach (Transform child in transform)
        {
            ammo.Add(child.gameObject);
            child.GetComponent<Renderer>().enabled = true;
        }
    }

    private void OnDestroy()
    {
        playerShoot.playerGuns.Remove(this);
    }

}
