using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static bool Level1, Level2, Level3, Level4;
    public Button Level1_Btn, Level2_Btn, Level3_Btn, Level4_Btn;
    public void Start()
    {
        Level1 = true;
    }

    private void Update()
    {
        if (Level1)
        {
            Level1_Btn.interactable = true;
        }
        if (Data.level.Contains("Level2"))
        {
            Level2_Btn.interactable = true;
        }
        if (Data.level.Contains("Level3"))
        {
            Level3_Btn.interactable = true;
        }
        if (Data.level.Contains("Level4"))
        {
            Level4_Btn.interactable = true;
        }
    }
}
