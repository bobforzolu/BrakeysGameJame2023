using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StatsGraphic : MonoBehaviour
{
    private string description;
    TextMeshProUGUI proUGUI;
    private HeroStats heroStats;
    void Start()
    {
        proUGUI = GetComponentInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        proUGUI.text = heroStats.ToStringStats();
    }
    public void SetHeroStats(HeroStats heroStats)
    {
        this.heroStats = heroStats;
    }
}
