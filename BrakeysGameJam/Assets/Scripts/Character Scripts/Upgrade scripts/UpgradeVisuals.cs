using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeVisuals : MonoBehaviour
{
    [SerializeField]private GameObject UpgradeOptionCanvas;
    private LevelSystem levelSystem;

    private void Start()
    {
       
        UpgradeOptionCanvas.SetActive(false);
    }
    public void GetLevelSytem(LevelSystem levelSystem)
    {
        this.levelSystem = levelSystem;

        levelSystem.OnLevelChanged += LevelSystem_OnLevelChanged;
    }
   
    private void LevelSystem_OnLevelChanged(object sender, System.EventArgs e)
    {
        StartCoroutine( PlayerUpgradeManager.instance.SelectUpgrades());
    }
    private void OnDestroy()
    {
        if(levelSystem != null)
        {
         levelSystem.OnLevelChanged -= LevelSystem_OnLevelChanged;

        }

    }
}
