using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenue : MonoBehaviour
{
   public void Quite()
    {

       
    }
    public void Resume()
    {
        GameController.instance.unpause();
        gameObject.SetActive(false);
    }
}
