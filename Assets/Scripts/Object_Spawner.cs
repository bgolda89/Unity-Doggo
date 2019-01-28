using UnityEngine;

public class Object_Spawner : MonoBehaviour
{
    
    public GameObject player;
    public GameObject[] bone;
    public GameObject clock, coin;

    private float boneSpawnTimer = 1.0f;
    private float clockSpawnTimer = 0.1f;
    private float coinSpawnTimer = 0.5f;
    private float distanceTraveled = 0;


    void Start()
    {
    }


    void Update()
    {
        boneSpawnTimer -= Time.deltaTime;
        clockSpawnTimer -= Time.deltaTime;
        coinSpawnTimer -= Time.deltaTime;

        if (!Game_Init.gameOver)
        {
            if (boneSpawnTimer < 0.01)
            {
                SpawnBone();
            }
            //if (clockSpawnTimer < 0.01)
            //{
            //    SpawnClock();
            //}
            //if (coinSpawnTimer < 0.01 && Data_Management.data_Management.boneCollected > 5)
            if (coinSpawnTimer < 0.01)
            {
                SpawnCoin();
            }
            else if (coinSpawnTimer < 0.01)
            {
                coinSpawnTimer = 3f;
            }
        }
    }

    void SpawnBone()
    {
        Instantiate(bone[(Random.Range(0, bone.Length))], new Vector3(Random.Range(9, -5), 1, player.transform.position.z + 130), Quaternion.identity);
        boneSpawnTimer = Random.Range(1.5f, 4.5f);
    }

    void SpawnClock()
    {
        Instantiate(clock, new Vector3(Random.Range(4, -4), 1, player.transform.position.z + 130), Quaternion.identity);
        clockSpawnTimer = Random.Range(2.5f, 5.5f);
    }

    void SpawnCoin()
    {
        Instantiate(coin, new Vector3(Random.Range(4, -4), 2, player.transform.position.z + 130), Quaternion.identity);
        coinSpawnTimer = Random.Range(3.8f, 5.0f);
    }
}
