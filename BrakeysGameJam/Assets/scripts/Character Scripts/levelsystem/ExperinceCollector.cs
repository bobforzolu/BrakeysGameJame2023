using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperinceCollector : MonoBehaviour
{
    private LevelSystem levelsystem;
    // Start is called before the first frame update
    
    public void SetLevelSystem(LevelSystem levelSystem)
    {
        levelsystem= levelSystem;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Experince"))
        {
            ExperincePoint exp = collision.gameObject.GetComponent<ExperincePoint>();
            levelsystem.Addexperince(exp.AwardExperince());
        }
    }
}
