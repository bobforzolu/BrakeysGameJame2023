using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperincePoint : MonoBehaviour
{
    [SerializeField]public int experince;


    public int AwardExperince()
    {
        return experince;
    }
}
