using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUpgradeManager : MonoBehaviour
{
   [SerializeField] private List<StatsUpgrade> statsUpgrades = new List<StatsUpgrade>();
    public List<SelectUpgrades> UpgradeButtons = new List<SelectUpgrades>();
    private List<StatsUpgrade> selectedUpgrades= new List<StatsUpgrade>();
    private GameObject canvas;
    public static PlayerUpgradeManager instance;
    

    private void Awake()
    {
       instance= this;
    }
    private void Start()
    {
        canvas = GameObject.FindGameObjectWithTag("Ui").transform.Find("Upgrade ui canvas").gameObject.transform.Find("upgradepanel").gameObject;
        UpgradeButtons.AddRange(canvas.GetComponentsInChildren<SelectUpgrades>());

    }

    public IEnumerator SelectUpgrades()
    {
        while(selectedUpgrades.Count < 3)
        {
            int randomindex = Random.Range(0,statsUpgrades.Count);
            StatsUpgrade randomUpgrade = statsUpgrades[randomindex];
            if(!selectedUpgrades.Contains(randomUpgrade)) 
            {
                selectedUpgrades.Add(randomUpgrade);
            }
            SetUpgradesToButton();
            canvas.SetActive(true);
        }
        yield return    null;

    }
    public void SetUpgradesToButton()
    {
        for (int i = 0; i < selectedUpgrades.Count; i++)
        {
            UpgradeButtons[i].SetUpgrade(selectedUpgrades[i]);
        }
    }
    public void ClearSelectUpgradeList()
    {
        selectedUpgrades.Clear();
    }
    public HeroStats GetHeroStats()
    {
     return   CharacterManager.instance.SelectedCharacter.GetComponent<HeroControler>().heroStats;
    }

}
