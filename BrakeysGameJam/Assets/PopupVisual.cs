using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PopupVisual : MonoBehaviour
{
    public TextMeshPro Damagetext;
    public VertexGradient colorGradient;
    private bool startmoving;
    public int alpha;


    private void Start()
    {
        
        
    }

    public void setDamage(int damage)
    {
        Damagetext.text = damage.ToString();
       Invoke( "Disableobj",1);
        startmoving= true;
    }

    private void Update()
    {
        if(startmoving)
        {
            transform.position += Vector3.up* 5 * Time.deltaTime;
        }
    }

    public void Disableobj()
    {
        startmoving= false;
        gameObject.SetActive(false);
    }
}
