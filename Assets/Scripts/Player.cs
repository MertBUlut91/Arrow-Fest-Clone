using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Text coin;
    public List<string> level;

    void Start()
    {
        Load();
    }
    private void FixedUpdate()
    {
        coin.text = Data.coin.ToString();
        level = Data.level;

    }

    public void Save()
    {
        Data.coin = int.Parse(coin.text);
        Data.level=level;

        SaveSystem.SavePlayer();
    }

    public void Load()
    {
        SaveSystem.LoadPlayer();
        coin.text = Data.coin.ToString();
        level = Data.level;

    }
}
