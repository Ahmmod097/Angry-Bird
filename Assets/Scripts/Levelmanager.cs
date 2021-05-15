using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Levelmanager : MonoBehaviour
{
    private Enemy[] No_of_enemy;
    public string SceneName;
    public AudioSource buttonClick;

    private void OnEnable()
    {
        No_of_enemy = FindObjectsOfType<Enemy>();
    }

    private void Update()
    {
        foreach (Enemy enemy  in No_of_enemy)
        {
            if (enemy != null)
            {
                return;
            }
            else
            {
                SceneManager.LoadScene(SceneName);
            }
        }
    }

    public void startGame(string sn)
    {
       
        SceneManager.LoadScene(sn);
    }
    public void clickAudio()
    {
        buttonClick.Play();
    }
    public void ExitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        // Application.Quit(); //Application.Quit () command does not work when testing the application in the Unity Editor
    }


    
}
