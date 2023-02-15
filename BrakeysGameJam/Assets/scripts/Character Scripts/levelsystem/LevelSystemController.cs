using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystemController : MonoBehaviour
{
    
    private LevelSystem levelSystem;
   private ExperinceCollector experinceCollector;
    private LevelVisual levelVisual;
    private UpgradeVisuals upgradeVisuals;
    private GameObject ui;
    private GameObject upgradeui;
    private void Awake()
    {
        levelSystem = new LevelSystem();
        
        ui = GameObject.FindGameObjectWithTag("Ui");
        upgradeui = ui.transform.Find("Upgrade ui canvas").gameObject;
        levelVisual = ui.GetComponentInChildren<LevelVisual>();
        upgradeVisuals= ui.GetComponentInChildren<UpgradeVisuals>();

    }
    private void Start()
    {
        experinceCollector = gameObject.GetComponentInChildren<ExperinceCollector>();
        levelVisual.SetLevelSystem(levelSystem);
        experinceCollector.SetLevelSystem(levelSystem);
        upgradeVisuals.GetLevelSytem(levelSystem);
        upgradeui.SetActive(false);
    }

}
