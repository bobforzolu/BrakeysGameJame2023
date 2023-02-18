using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenue : MonoBehaviour
{
   public void Quite()
    {

        SceneManager.LoadScene(SceneManager.GetSceneByBuildIndex(0).name);
    }
    public void Resume()
    {
        GameController.instance.unpause();
        gameObject.SetActive(false);
    }
}
