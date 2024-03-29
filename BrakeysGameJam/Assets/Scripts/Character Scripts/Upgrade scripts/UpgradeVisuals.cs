using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeVisuals : MonoBehaviour
{
    [SerializeField]private GameObject UpgradeOptionCanvas;
    private LevelSystem levelSystem;

    private void Start()
    {
       
    }
    public void GetLevelSytem(LevelSystem levelSystem)
    {
        this.levelSystem = levelSystem;

        levelSystem.OnLevelChanged += LevelSystem_OnLevelChanged;
        UpgradeOptionCanvas.SetActive(false);
    }
   
    private void LevelSystem_OnLevelChanged(object sender, System.EventArgs e)
    {
        StartCoroutine( PlayerUpgradeManager.instance.SelectUpgrades());
        GameController.instance.Pause();
    }
    private void OnDestroy()
    {
        if(levelSystem != null)
        {
         levelSystem.OnLevelChanged -= LevelSystem_OnLevelChanged;

        }

    }

}
