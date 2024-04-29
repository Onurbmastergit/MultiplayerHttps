using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnColetavel : MonoBehaviour
{
    
    public Transform prefabColetavel;
    public Transform spawnColetavel;

    public float spawnInterval = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnarMoeda", 5 , spawnInterval);

    }

    void SpawnarMoeda() 
    {

        float areaX = spawnColetavel.localScale.x / 2;
        float areaZ = spawnColetavel.localScale.z / 2;

        float randomX = Random.Range(-areaX, areaZ);
        float randomZ = Random.Range(-areaZ, areaX);

        Vector3 localSpawn = new Vector3 (randomX, 1f ,randomZ);

       Transform instacia = Instantiate(prefabColetavel , transform );
        instacia.position = localSpawn;
    }
}
