using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelEnd : MonoBehaviour
{
    public void Level1End()
    {
        Data.level.Add("Level2");
        SaveSystem.SavePlayer();
        SceneManager.LoadScene(0);
    }
    public void Leve2End()
    {
        Data.level.Add("Level3");
        SaveSystem.SavePlayer();

        SceneManager.LoadScene(0);
    }
    public void Level3End()
    {
        Data.level.Add("Level4");
        SaveSystem.SavePlayer();
        SceneManager.LoadScene(0);
    }
}
