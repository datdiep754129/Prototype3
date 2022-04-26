using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private float startDelay = 2;
    private float repeatRate = 2;
    public GameObject obstaclePrefabs;
    private Vector3 spawnPosition = new Vector3(25, 0, 0);
    private PlayerController playerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        playerControllerScript = GameObject.Find("Player").GetComponent <PlayerController>();
        //Instantiate(obstaclePrefabs, spawnPosition, obstaclePrefabs.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void SpawnObstacle()
    {
        if (playerControllerScript.gameOver == false)
        {
            Instantiate(obstaclePrefabs, spawnPosition, obstaclePrefabs.transform.rotation);
        }
    }
}
