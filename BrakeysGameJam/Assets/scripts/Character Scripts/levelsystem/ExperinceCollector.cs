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
        if (collision.CompareTag("ExperincePoints"))
        {
            ExperincePoint exp = collision.gameObject.GetComponentInParent<ExperincePoint>();
            if (exp != null)
            {

                levelsystem.Addexperince(exp.AwardExperince());
                collision.gameObject.SetActive(false);
            }
        }
    }
    
}
