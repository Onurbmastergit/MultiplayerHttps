using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public static PlayerSpawner instacia;

    public Transform playerPrefab;
    public Transform spawnLocation;
    void Awake()
    {
        instacia = this;
    }
    public void SpawnPlayer()
    {
        Transform createdPlayer = Instantiate(playerPrefab);
        createdPlayer.transform.position = spawnLocation.transform.position;       
    }
}
