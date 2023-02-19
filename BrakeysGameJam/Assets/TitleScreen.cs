using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    public GameObject OptionCanvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Options()
    {
        OptionCanvas.SetActive(true);
        gameObject.SetActive(false);
    }
    public void Startgame()
    {
        SceneManager.LoadScene(SceneManager.GetSceneByName("GameScene").buildIndex);
    }
    public void ApplicationQuite()
    {
        Application.Quit();
    }
}
