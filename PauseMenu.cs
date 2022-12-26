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
       // Debug.Log(test);
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
        if (enabled)
        {
            audioMixer.audioMixer.SetFloat("MusicVolume", 0);
            test = true;
        }
        else
        {
            audioMixer.audioMixer.SetFloat("MusicVolume", -80);
            test = false;
        }
    }

    public void ToggleSFX(bool enabled)
    {
        if (enabled)
        {
            audioMixer.audioMixer.SetFloat("SFXVolume", 0);
            test = true;
        }
        else
        {
            audioMixer.audioMixer.SetFloat("SFXVolume", -80);
            test = false;
        }
    }

    public void ChangeVolume(float volume) 
    {
        audioMixer.audioMixer.SetFloat("MasterVolume", Mathf.Lerp(-80, 0, volume));
    }
    public void NextStage()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }
}
