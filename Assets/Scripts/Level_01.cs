using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_01 : MonoBehaviour {

    public GameObject player, eolUI, playerUI;
    public float levelLength = 100f;
    private Player_Con_New controller;

    void Start()
    {
        controller = FindObjectOfType<Player_Con_New>();
    }

    void Update()
    {
        if (player.transform.position.z >= levelLength && !Game_Init.gameOver)
        {
            eolUI.SetActive(true);
            Game_Init.gameOver = true;
            controller.enabled = false;
            playerUI.SetActive(false);
        }
    }

}