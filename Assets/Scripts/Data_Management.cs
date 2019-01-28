using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class Data_Management : MonoBehaviour
{

    public static Data_Management data_Management;
    public int currentScore;
    public int highScore;
    public int boneCollected;
    public int maxHealth;
    public int currentHealth;
    public float secondsLeft;


    void Awake()
    {
        if (data_Management == null)
        {
            DontDestroyOnLoad(gameObject);
            data_Management = this;
        }
        else if (data_Management != this)
        {
            Destroy(gameObject);
        }
    }

    public void SaveData()
    {
        BinaryFormatter binaryForm = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gameInfo.dat");
        gameData data = new gameData();
        data.highScore = data_Management.highScore;
        data.boneCollected = data_Management.boneCollected;
        binaryForm.Serialize(file, data);
        file.Close();
    }

    public void LoadData()
    {
        if (File.Exists(Application.persistentDataPath + "/gameInfo.dat"))
        {
            BinaryFormatter binaryForm = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gameInfo.dat", FileMode.Open);
            gameData data = (gameData)binaryForm.Deserialize(file);
            file.Close();
            highScore = data.highScore;
            boneCollected = data.boneCollected;
            //data_Management.boneCollected = Game_Init.bonesCollected;
            currentHealth = data_Management.maxHealth;
            Debug.Log("loaded data");
        }
    }

    public void TookDamage(){
        currentHealth -= 1;
    }
}

[Serializable]
class gameData
{
    public int highScore;
    public int boneCollected;
    public float secondsLeft;
}
