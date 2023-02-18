using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropExperince : MonoBehaviour
{
    public GameObject experince;
    public void DropExp()
    {
        Instantiate(experince, new Vector2(transform.position.x, transform.position.y), Quaternion.identity); 
    }

}
