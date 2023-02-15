using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class PlayerManager : MonoBehaviour
{
    [SerializeField] private GameObject[] character;
    [SerializeField]private List<GameObject> characterLineUP = new List<GameObject>();
    private int currentCharacter;
    private int prestige;

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
