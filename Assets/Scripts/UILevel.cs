using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILevel : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject levelMenu;
    public void ShowLevelMenu()
    {
        mainMenu.SetActive(false);
        levelMenu.SetActive(true);
    }

}
