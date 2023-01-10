using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour
{

    public bool PauseGame;
    public GameObject pauseGameMenu;
    public AudioMixerGroup audioMixer;
    private bool test;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {

            if (PauseGame)
            {
                Resume();
            }
            else 
            {
                Pause();
            }
        
        }
    }

    public void Resume()
    {
        pauseGameMenu.SetActive(false);
        Time.timeScale = 1f;
        PauseGame = false;  
    }

    public void Pause() 
    {
        pauseGameMenu.SetActive(true);
        Time.timeScale = 0f;
        PauseGame = true;


    }
    public void LoadMenu() 
    
    { 
        Time.timeScale = 1f;
        SceneManager.LoadScene("StartMenu");
    
    }
    public void LoadStage1()

    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("1");

    }
    public void LoadStage1b()

    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("1b");

    }
    public void LoadStage2()

    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("2.1");

    }
    public void LoadStage2b()

    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("2b");

    }
    public void ToggleMusic(bool enabled) 
    {
        // Check if music is enabled
        if (enabled)
        {
            // Set the volume of the "MusicVolume" audio mixer group to 0 (full volume)
            audioMixer.audioMixer.SetFloat("MusicVolume", 0);
            test = true;
        }
        else
        {
            // Set the volume of the "MusicVolume" audio mixer group to -80 (muted)
            audioMixer.audioMixer.SetFloat("MusicVolume", -80);
            test = false;
        }
    }

    public void ToggleSFX(bool enabled)
    {
        // Check if SFX is enabled
        if (enabled)
        {
            // Set the volume of the "SFXVolume" audio mixer group to 0 (full volume)
            audioMixer.audioMixer.SetFloat("SFXVolume", 0);
            test = true;
        }
        else
        {
            // Set the volume of the "SFXVolume" audio mixer group to -80 (muted)
            audioMixer.audioMixer.SetFloat("SFXVolume", -80);
            test = false;
        }
    }

    public void ChangeVolume(float volume) 
    {
        // Set the volume of the "MasterVolume" audio mixer group based on the volume input
        // where 0 is the minimum value (-80) and 1 is the maximum (0)
        audioMixer.audioMixer.SetFloat("MasterVolume", Mathf.Lerp(-80, 0, volume));
    }
    public void NextStage()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }
}
