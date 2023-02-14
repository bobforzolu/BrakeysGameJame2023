using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelVisual : MonoBehaviour
{
   [SerializeField] private Slider expBar;
   [SerializeField] private TextMeshProUGUI textMeshPro;
    private LevelSystem levelSystem;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void SetLevel(int level)
    {
        string text = "level: " + level;
        textMeshPro.text = text;
    }
    public void SetExperince(int experience)
    {

    }
    // Update is called once per frame
    public void SetLevelSystem(LevelSystem levelSystem)
    {
        this.levelSystem = levelSystem;
        SetLevel(levelSystem.GetLevelNumber());
        
    }
}
