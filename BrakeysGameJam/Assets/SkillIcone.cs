using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillIcone : MonoBehaviour
{
    public Image skill1;
    public Image skill2;

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    public void seticone(AbilityIconeData iconeData)
    {
        skill1.sprite = iconeData.icone1;
        skill2.sprite = iconeData.icone2;





    }




}
