using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawner : MonoBehaviour {
    
    public GameObject car, log, doggo, hooman;
    public GameObject[] sign, tree;
    private float carSpawnTimer = 0.6f;
    private float treeSpawnTimer = 0.6f;
    private float signSpawnTimer = 0.6f;
    private float carRevSpawnTimer = 0.1f;
    private float logSpawnTimer = 1.0f;
    private float playerZ;

	void Update () {
        playerZ = ((doggo.transform.position.z + hooman.transform.position.z) / 2);
        carSpawnTimer -= Time.deltaTime;
        treeSpawnTimer -= Time.deltaTime;
        signSpawnTimer -= Time.deltaTime;
        carRevSpawnTimer -= Time.deltaTime;
        logSpawnTimer -= Time.deltaTime;

        if (!Game_Init.gameOver)
        {
            if (carSpawnTimer < 0.01)
            {
                SpawnCar();
            }
            if (carRevSpawnTimer < 0.01)
            {
                SpawnCarRev();
            }
            if (signSpawnTimer < 0.01)
            {
                SpawnSign();
            }
            if (treeSpawnTimer < 0.01)
            {
                SpawnTree();
                SpawnFarTree();
            }
            if (logSpawnTimer < 0.01)
            {
                SpawnLog();
            }
        }
	}

    void SpawnSign()
    {
        Instantiate(sign[(Random.Range(0, sign.Length))], new Vector3(Random.Range(-3, 5), 0.75f, playerZ + 100), Quaternion.Euler(0,90,0));
        signSpawnTimer = Random.Range(3.0f, 6.0f);
    }

    void SpawnCar()
    {
        GameObject spawnedCar = Instantiate(car, new Vector3(-15, 1, playerZ + 100), Quaternion.identity);
        spawnedCar.transform.GetComponent<Rigidbody>().AddForce(0, 0, Random.Range(-50, -70), ForceMode.VelocityChange);
        spawnedCar.GetComponentInChildren<Renderer>().material.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
        carSpawnTimer = Random.Range(0.45f, 3.25f);
    }

    void SpawnCarRev ()
    {
        GameObject spawnedCar = Instantiate(car, new Vector3(-11, 1, playerZ - 10), Quaternion.identity);
        spawnedCar.transform.GetComponent<Rigidbody>().AddForce(0, 0, Random.Range(70, 90), ForceMode.VelocityChange);
        spawnedCar.GetComponentInChildren<Renderer>().material.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
        carRevSpawnTimer = Random.Range(0.45f, 3.25f);
    }

    void SpawnTree()
    {
        float xpos = Random.Range(12.0f, 45.0f);
        float ypos = 0f;
        if (xpos > 24)
        {
            ypos = xpos - 24;
        }
        GameObject spawnedTree = Instantiate(tree[(Random.Range(0, tree.Length))], new Vector3(xpos, ypos, playerZ + 130), Quaternion.Euler(0, Random.Range(0, 360), 0));
        float xzScale = Random.Range(0.4f, 0.9f);
        spawnedTree.transform.localScale = new Vector3(xzScale, Random.Range(0.5f, 1.3f), xzScale);
        treeSpawnTimer = Random.Range(0.01f, 0.1f);
    }

    void SpawnLog()
    {
        float xpos = Random.Range(3, 20);
        float spinMult = 0;
        if (xpos > 10){
            spinMult = Random.Range(0,15);
        }
        GameObject spawnedLog = Instantiate(log, new Vector3(xpos, 0, playerZ + 130), Quaternion.Euler(0, Random.Range(-20, 20) * spinMult, 0));
        spawnedLog.transform.localScale = new Vector3(Random.Range(1, 4), 1, 1);
        logSpawnTimer = Random.Range(1.5f, 3.0f);
    }

    void SpawnFarTree()
    {
        float xpos = Random.Range(-23.0f, -50.0f);
        float ypos = 0f;
        if (xpos < -34)
        {
            ypos = (xpos + 34) / 2 ;
        }
        GameObject spawnedTree = Instantiate(tree[(Random.Range(0, tree.Length))], new Vector3(xpos, ypos, playerZ + 130), Quaternion.Euler(0, Random.Range(0, 360), 0));
        float xzScale = Random.Range(0.4f, 0.9f);
        spawnedTree.transform.localScale = new Vector3(xzScale, Random.Range(0.5f, 1.3f), xzScale);
    }
}
