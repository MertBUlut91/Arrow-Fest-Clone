using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menus : SingletonScript<Menus>
{
    [SerializeField] GameObject lostMenu;
    [SerializeField] GameObject winMenu;
    private void Start()
    {
        Time.timeScale = 1;
    }

    public void OpenLostMenu()
    {
        lostMenu.SetActive(true);
        Time.timeScale = 0;
    }
    public void OpenWinMenu()
    {
        winMenu.SetActive(true);
        Time.timeScale = 0;
    }
    public void Retry()
    {
        SaveSystem.SavePlayer();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void StartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
