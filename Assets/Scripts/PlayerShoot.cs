using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
   public  List<PlayerGun> playerGuns = new List<PlayerGun>();
   Vector3 worldPosition;
    [SerializeField] GameObject playerMissle;
    [SerializeField] GameObject destinationVisualPointPrefab;
    [SerializeField] AudioSource audioSource;
    [SerializeField] GameObject textNoAmmo;
    public bool canShoot = false;


    void CursorPosition()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CursorPosition();
            if (!canShoot || worldPosition.y < -2.6f)
            {
                textNoAmmo.SetActive(!canShoot);
                audioSource.Play();
                return;
            }

            float distance  =10000000000f;
            Vector3 whichGunPosition = Vector3.zero;
            PlayerGun tempGun = null;
            foreach (var p in playerGuns)
            {
                if(distance>Vector3.Distance(worldPosition, p.transform.position) && p.ammo.Count > 0)
                {
                    distance = Vector3.Distance(worldPosition, p.transform.position);
                    whichGunPosition = p.transform.position;
                    tempGun = p;
                }
            }
            if (distance == 10000000000f)
            {
                canShoot = false;
                return;
            }
            tempGun.ammo[tempGun.ammo.Count - 1].GetComponent<Renderer>().enabled = false;
            tempGun.ammo.RemoveAt(tempGun.ammo.Count - 1);
            var missle =  Instantiate(playerMissle, whichGunPosition, Quaternion.identity);
            var targetPositionVisual = Instantiate(destinationVisualPointPrefab, worldPosition, Quaternion.identity);

            var misslePlayerMissle = missle.GetComponent<PlayerMissle>();
            misslePlayerMissle.targetDestination = worldPosition;
            misslePlayerMissle.destinationVisualPoint = targetPositionVisual;
        }
    }
}
