using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperincePoint : MonoBehaviour
{
    [SerializeField]private int experince;


    public int AwardExperince()
    {
        return experince;
    }
}
