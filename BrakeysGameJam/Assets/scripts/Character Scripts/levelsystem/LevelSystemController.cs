using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystemController : MonoBehaviour
{
    
    private LevelSystem levelSystem;
   [SerializeField] private ExperinceCollector experinceCollector;
    [SerializeField]private LevelVisual levelVisual;
    [SerializeField] private UpgradeVisuals upgradeVisuals;
    private void Awake()
    {
        levelSystem = new LevelSystem();
        
    }
    private void Start()
    {
        experinceCollector = transform.parent.GetComponentInChildren<ExperinceCollector>();
        levelVisual =transform.parent.GetComponentInChildren<LevelVisual>();
        levelVisual.SetLevelSystem(levelSystem);
        experinceCollector.SetLevelSystem(levelSystem);
        upgradeVisuals= transform.parent.GetComponentInChildren<UpgradeVisuals>();
        upgradeVisuals.GetLevelSytem(levelSystem);
    }
    private void Update()
    {
        
    }
}
