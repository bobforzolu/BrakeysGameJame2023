using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectUpgrades : MonoBehaviour
{
    /// get refrance to a scriptable object holding the upgrade 
    public GameObject upgradeCanvas;
    public void SelectUpgrade()
    {
        /// execute the upgrade
         
        ///close the window
        CloseUi();
    }

    public void CloseUi()
    {
        upgradeCanvas.SetActive(false);
    }
}
