using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveSystem 
{

    public static void SavePlayer()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream("player.bin", FileMode.Create);

        formatter.Serialize(stream, Data.coin);
        formatter.Serialize(stream, Data.level);

        stream.Close();
    }

    public static void LoadPlayer()
    {
        if (File.Exists("player.bin"))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream("player.bin", FileMode.Open);
            Data.coin = (int) formatter.Deserialize(stream);
            Data.level = (List<string>) formatter.Deserialize(stream);



            stream.Close();
        }
        else
        {
            Debug.LogError("No Save Data");
        }

    }
}
