using UnityEngine;

public class Game_Init : MonoBehaviour {

    public static bool gameOver;
    Data_Management data_Management;

    void Start()
    {
        data_Management = FindObjectOfType<Data_Management>();
        data_Management.LoadData();
        gameOver = false;
    }
}
