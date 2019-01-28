using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class Player_UI : MonoBehaviour {
    
    public GameObject progressBar, speedBar, player, scoreWindow, healthBar;
    Data_Management data_Management;
    public float score = 0;
    public int currentHealth, maxHealth;
    float levelLength, maxMoveSpeed, currentMoveSpeed;

	void Start () {
        data_Management = FindObjectOfType<Data_Management>();
        levelLength = FindObjectOfType<Level_01>().levelLength;
        maxMoveSpeed = FindObjectOfType<Player_Con_New>().maxMoveSpeed;
        currentMoveSpeed = FindObjectOfType<Player_Con_New>().moveSpeed;
        scoreWindow.GetComponentInChildren<TextMeshProUGUI>().text = score.ToString();
        currentHealth = FindObjectOfType<Data_Management>().currentHealth;
        maxHealth = FindObjectOfType<Data_Management>().maxHealth;
	}
	
	void Update () {
        score = player.transform.position.z * 10;
        currentMoveSpeed = FindObjectOfType<Player_Con_New>().moveSpeed;

        if (currentHealth == 0){
            FindObjectOfType<Player_Col>().PlayerDies();
        }

        healthBar.transform.localScale = new Vector3(1, (float)currentHealth / maxHealth, 1);
        speedBar.transform.localScale = new Vector3(1, currentMoveSpeed / maxMoveSpeed, 1);
        progressBar.transform.localScale = new Vector3((player.transform.position.z / levelLength),1,1);
        scoreWindow.GetComponentInChildren<TextMeshProUGUI>().text = score.ToString("0");
	}
}
