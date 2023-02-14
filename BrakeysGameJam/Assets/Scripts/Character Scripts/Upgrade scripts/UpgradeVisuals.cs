using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeVisuals : MonoBehaviour
{
    [SerializeField]private GameObject UpgradeOptionCanvas;
    private LevelSystem levelSystem;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GetLevelSytem(LevelSystem levelSystem)
    {
        this.levelSystem = levelSystem;

        levelSystem.OnLevelChanged += LevelSystem_OnLevelChanged;
    }

    private void LevelSystem_OnLevelChanged(object sender, System.EventArgs e)
    {
        UpgradeOptionCanvas.SetActive(true);
    }
}
