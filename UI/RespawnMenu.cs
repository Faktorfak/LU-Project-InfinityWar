using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnMenu : MonoBehaviour
{
    public bool respawnMenu;
    public GameObject respawnMenuPrefab;
    public HealthBar healthBar;



    void Update()
    {
        if (Movement.lives == 0) {

            respawnMenuPrefab.SetActive(true);
            Time.timeScale = 0f;
            respawnMenu = true;
            
        }
        

    }
    public void RestartT()
    {

        SceneManager.LoadScene("Tutorial");
        Movement.lives = 3;
        Time.timeScale = 1f;

    }
    public void Restart() 
    {
       
        SceneManager.LoadScene("1");
        Movement.lives = 3;
        Time.timeScale = 1f;
        
    }

    public void Restart2()
    {

        SceneManager.LoadScene("2.1");
        Movement.lives = 3;
        Time.timeScale = 1f;

    }
    public void Restart3()
    {

        SceneManager.LoadScene("2b");
        Movement.lives = 3;
        Time.timeScale = 1f;

    }
    public void LoadMenu()

    {
        respawnMenuPrefab.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("StartMenu");
        Movement.lives = 3;
    }
}
