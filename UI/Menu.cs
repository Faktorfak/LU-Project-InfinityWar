using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    
    }

    public void ExitGame() {
        
        
        Debug.Log("Closed");
        Application.Quit();
    
    }

    public void Level1() 
    {
        SceneManager.LoadScene(1);

    }

    public void Level2()
    {
        SceneManager.LoadScene(2);

    }

    public void Level3()
    {
        SceneManager.LoadScene(3);

    }

}
