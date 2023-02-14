using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystemController : MonoBehaviour
{
    
    private LevelSystem levelSystem;
    private ExperinceCollector experinceCollector;
    private LevelVisual levelVisual;
    private UpgradeVisuals upgradeVisuals;
    private void Awake()
    {
        levelSystem = new LevelSystem();
        
    }
    private void Start()
    {
        experinceCollector = GetComponentInChildren<ExperinceCollector>();
        levelVisual = GetComponentInChildren<LevelVisual>();
        levelVisual.SetLevelSystem(levelSystem);
        experinceCollector.SetLevelSystem(levelSystem);
        upgradeVisuals= GetComponentInChildren<UpgradeVisuals>();
        upgradeVisuals.GetLevelSytem(levelSystem);
    }
    private void Update()
    {
        
    }
}
