using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenue : MonoBehaviour
{
   public void Quite()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);


    }
    public void Resume()
    {
        GameController.instance.unpause();
        gameObject.SetActive(false);
    }
}
