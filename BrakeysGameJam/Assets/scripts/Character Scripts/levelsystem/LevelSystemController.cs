using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystemController : MonoBehaviour
{
    
    public LevelSystem levelSystem { get; private set; }
    private ExperinceCollector experinceCollector;
    private LevelVisual levelVisual;
    public UpgradeVisuals upgradeVisuals;
    public GameObject ui;
    public GameObject upgradeui;
    private HeroControler heroControler;
    private HeroHealthVisual visual;
    private void Awake()
    {
        levelSystem = new LevelSystem();
        

        //upgradeui = ui.transform.Find("upgradepanel").gameObject;
        
        ui = GameObject.FindGameObjectWithTag("Ui");
        levelVisual = ui.GetComponentInChildren<LevelVisual>();
        upgradeVisuals= ui.GetComponentInChildren<UpgradeVisuals>();
        visual =GetComponentInChildren<HeroHealthVisual>();
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
        visual.SetlevelSystem(levelSystem);

    }

}
