using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public  class CharacterManager : MonoBehaviour
{
    public CharacterManager instance { get; private set; }
    public EventHandler OnCharacterSpawn { get; private set; }

    [SerializeField] private GameObject[] character;
    [SerializeField]private List<GameObject> characterLineUP = new List<GameObject>();
    private int currentCharacter;
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
        
    }
}
