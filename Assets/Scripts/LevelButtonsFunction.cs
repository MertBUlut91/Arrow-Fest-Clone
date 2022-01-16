using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelButtonsFunction : MonoBehaviour
{
    public void Lvl1()
    {
        SceneManager.LoadScene("Level1");
    }
    public void Lvl2()
    {
        SceneManager.LoadScene("Level2");
    }
    public void Lvl3()
    {
        SceneManager.LoadScene("Level3");
    }
    public void Lvl4()
    {
        SceneManager.LoadScene("Level4");
    }
}
