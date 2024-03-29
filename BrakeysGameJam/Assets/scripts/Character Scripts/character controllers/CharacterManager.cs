using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Cinemachine;

public  class CharacterManager : MonoBehaviour
{
    public static CharacterManager instance { get; private set; }
    #region character Variables
    public event EventHandler<OncharterlevelArgs> OnCharacterSpawn;
    public class OncharterlevelArgs: EventArgs
    {
        public HeroStats heroStats;
    }

    public CinemachineVirtualCamera cam;
    [SerializeField] private GameObject[] character;
    [SerializeField]private List<GameObject> characterLineUP = new List<GameObject>();
    private List<GameObject> UsedCharachters= new List<GameObject>();
    public GameObject SelectedCharacter;
    public HeroControler heroControler { get; private set; }
    public SkillIcone skillUi;
    #endregion
    private int characterIndex;
    private int prestige;
    public HeroStats heroStats { get; private set; }
    public StatsGraphic statsGraphic;
    public GameObject PauseMenue;
    public GameObject Gameover;
    public GameObject victory;
    private void Awake()
    {
        
        instance = this;
    }
    private void Start()
    {
        SetUpCharacter();
    }
    private void Update()
    {
        if (EnemySpawner.enemySpawner.currentEnemy <= 10 && EnemySpawner.enemySpawner.SpawnEnd)
        {
            victory.SetActive(true);
            GameController.instance.Pause();
        }
    }

    public void SetUpCharacter()
    {
        for (int i = 0; i < character.Length; i++)
        {
            characterLineUP.Add(character[i]);
        }
        
        SummonCharacter();

        
    }
    public void SummonCharacter()
    {
        if(characterLineUP.Count > 0)
        {
        // get the max character in the list
        int maxRange = characterLineUP.Count ;
        // get a random number
        characterIndex = UnityEngine.Random.Range(0, maxRange);
        // get the character in the list
        SelectedCharacter= Instantiate(characterLineUP[characterIndex].gameObject,new Vector2(0,0), Quaternion.identity);
        cam.Follow = SelectedCharacter.transform;
        // remove the character in the line up list
        characterLineUP.RemoveAt(characterIndex);
        // add it to the used character list
        UsedCharachters.Add(SelectedCharacter);
        heroControler = SelectedCharacter.GetComponent<HeroControler>();
        heroStats = heroControler.heroStats;
            if(prestige > 0 && EnemySpawner.enemySpawner.currentWave >= 2)
            {
                heroStats.IncreasAllStats(20);
            }
            else if (prestige > 0 && EnemySpawner.enemySpawner.currentWave > 4)
            {
                heroStats.IncreasAllStats(50);

            }
            skillUi.seticone(SelectedCharacter.GetComponent<HeroControler>().skilliconData);
        statsGraphic.SetHeroStats(heroStats);
        heroControler.OnPlayerDeath += HeroControler_OnPlayerDeath;
        PauseMenue.SetActive(false);
            prestige++;

        }
        else
        {
            GameOver();
        }
        


    }

    private void HeroControler_OnPlayerDeath(object sender, EventArgs e)
    {
        SummonCharacter();
    }

    public void SetUpExpt()
    {

    }
    private void OnDisable()
    {
        heroControler.OnPlayerDeath -= HeroControler_OnPlayerDeath;

    }
    public void GameOver()
    {
        ///gameover
        Gameover.SetActive(true);
        GameController.instance.Pause();
    }
}
