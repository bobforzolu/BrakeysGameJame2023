using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    private void Awake()
    {
        if(instance !=null)
        {
            Destroy(gameObject);
        }
        instance = this;
    }
    private void Start()
    {
        
    }
    public void Pause()
    {
        Time.timeScale = 0;
    }
    public void unpause()
    {
        Time.timeScale = 1;
    }
}
