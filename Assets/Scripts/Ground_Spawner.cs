using UnityEngine;

public class Ground_Spawner : MonoBehaviour {

    public GameObject player;
    public GameObject[] ground;
    Vector3 startPos, lastPosition;
    private float distanceTraveled = 0;

	void Start () {
        lastPosition = startPos = player.transform.position;
        Instantiate(ground[0], new Vector3(0, 0, startPos.z + 50), Quaternion.identity);
        Instantiate(ground[0], new Vector3(0, 0, startPos.z + 100), Quaternion.identity);
        Instantiate(ground[Random.Range(0, ground.Length)], new Vector3(0, 0, startPos.z + 150), Quaternion.identity);
        Instantiate(ground[Random.Range(0, ground.Length)], new Vector3(0, 0, startPos.z + 200), Quaternion.identity);
        startPos.z = startPos.z + 250;
	}
	
	void Update () {
        distanceTraveled += Vector3.Distance(player.transform.position, lastPosition);
        if (!Game_Init.gameOver)
        {
            if (distanceTraveled >= 50)
            {
                SpawnGround();
                distanceTraveled = 0;
            }
        }
        lastPosition = player.transform.position;
	}

    void SpawnGround()
    {
        Instantiate(ground[Random.Range(0,ground.Length)], new Vector3(0, 0, startPos.z), Quaternion.identity);
        startPos.z = startPos.z + 50;
    }
}
