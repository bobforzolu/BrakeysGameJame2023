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
        expBar.value = experience;
    }
    // Update is called once per frame
    public void SetLevelSystem(LevelSystem levelSystem)
    {
        this.levelSystem = levelSystem;
        SetLevel(levelSystem.GetLevelNumber());

        expBar.minValue = 0;
        expBar.maxValue = levelSystem.GetExperineceToNextLevel();
        SetExperince(levelSystem.GetExperience());
        levelSystem.OnLevelChanged += LevelSystem_OnLevelChanged;
        levelSystem.OnExperinceEarned += LevelSystem_OnExperinceEarned;
        
    }

    private void LevelSystem_OnExperinceEarned(object sender, System.EventArgs e)
    {
        SetExperince(levelSystem.GetExperience());
    }

    private void LevelSystem_OnLevelChanged(object sender, System.EventArgs e)
    {
        SetLevel(levelSystem.GetLevelNumber());
    }
}
