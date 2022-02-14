using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    [SerializeField] GameObject canvasMainMenu;
    [SerializeField] PlayerShoot playerShoot;
    [SerializeField] GameObject canvasScore;
    [SerializeField] GameObject canvasEndGame;
    [SerializeField] GameObject textNoAmmo;
    static bool tryAgain = false;
    void Awake()
    {
        Time.timeScale = 0;
    }
    private void Start()
    {
        canvasMainMenu.SetActive(true);
        canvasScore.SetActive(false);
        canvasEndGame.SetActive(false);
        if (tryAgain)
            StartButton();
    }
    public void StartButton()
    {
        canvasMainMenu.SetActive(false);
        canvasScore.SetActive(true);
        Time.timeScale = 1;
        playerShoot.canShoot = true;
        textNoAmmo.SetActive(false);

    }

    public void TryAgainButton()
    {
        EnemyMissle.missleSpeedEnemy = 1f;
        tryAgain = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
