using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void PlayGame()
    {
        // This function loads the next scene in the build index
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);    
    }

    public void ExitGame() {
        // This function closes the game application
        Debug.Log("Closed");
        Application.Quit();
    
    }

    public void Level1() 
    {
        // This function loads scene 1
        SceneManager.LoadScene(1);
    }

    public void Level2()
    {
        // This function loads scene 2
        SceneManager.LoadScene(2);

    }

    public void Level3()
    {
        // This function loads scene 3
        SceneManager.LoadScene(3);
    }

}
