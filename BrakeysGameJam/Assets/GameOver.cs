using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void PlayAgin()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void mainMeneu() 
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
    }
}
