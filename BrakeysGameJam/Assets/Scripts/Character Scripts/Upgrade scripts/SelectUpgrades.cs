using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectUpgrades : MonoBehaviour
{
    /// get refrance to a scriptable object holding the upgrade 
    public GameObject upgradeCanvas;
    public StatsUpgrade statsUpgrade;
    public HeroStats heroStats;
    public TextMeshProUGUI Description;
    
    private void Start()
    {
    }
    private void OnEnable()
    {
        if(statsUpgrade!= null)
        {
        Description.text = statsUpgrade.description + statsUpgrade.StatsIncreaseAmount.ToString();
        Debug.Log(heroStats);

        }
    }
    public void SelectUpgrade()
    {
        /// execute the upgrade
        statsUpgrade.Upgrade(PlayerUpgradeManager.instance.GetHeroStats());
        ///close the window
        PlayerUpgradeManager.instance.ClearSelectUpgradeList();
        CloseUi();
    }
    public void SetUpgrade( StatsUpgrade statsUpgrade)
    {
        this.statsUpgrade = statsUpgrade;


    }

    public void CloseUi()
    {
        upgradeCanvas.SetActive(false);
    }
}
