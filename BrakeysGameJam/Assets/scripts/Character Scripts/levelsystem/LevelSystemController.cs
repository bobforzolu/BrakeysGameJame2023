using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystemController : MonoBehaviour
{
    
    public LevelSystem levelSystem { get; private set; }
    private ExperinceCollector experinceCollector;
    private LevelVisual levelVisual;
    private UpgradeVisuals upgradeVisuals;
    private GameObject ui;
    private GameObject upgradeui;
    private HeroControler heroControler;
    private void Awake()
    {
        levelSystem = new LevelSystem();
        
        ui = GameObject.FindGameObjectWithTag("Ui");
        upgradeui = ui.transform.Find("Upgrade ui canvas").gameObject;
        levelVisual = ui.GetComponentInChildren<LevelVisual>();
        upgradeVisuals= ui.GetComponentInChildren<UpgradeVisuals>();
        heroControler = GetComponent<HeroControler>();
    }
    private void OnDisable()
    {
        levelSystem.OnLevelChanged -= LevelSystem_OnLevelChanged;
    }

    private void LevelSystem_OnLevelChanged(object sender, System.EventArgs e)
    {
        heroControler.heroStats.ToStringStats();
    }

    private void Start()
    {
        experinceCollector = gameObject.GetComponentInChildren<ExperinceCollector>();
        levelVisual.SetLevelSystem(levelSystem);
        experinceCollector.SetLevelSystem(levelSystem);
        upgradeVisuals.GetLevelSytem(levelSystem);
        levelSystem.OnLevelChanged += LevelSystem_OnLevelChanged;

    }

}
