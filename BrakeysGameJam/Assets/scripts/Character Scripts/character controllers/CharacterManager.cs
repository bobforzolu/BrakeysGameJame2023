using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Cinemachine;

public  class CharacterManager : MonoBehaviour
{
    public static CharacterManager instance { get; private set; }
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
    public SkillIcone skillUi;
    private int characterIndex;
    private int prestige;
    private void Awake()
    {
        
        instance = this;
    }
    private void Start()
    {
        SetUpCharacter();
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
        skillUi.seticone(SelectedCharacter.GetComponent<HeroControler>().skilliconData);
        


    }
    public void SetUpExpt()
    {

    }
}
