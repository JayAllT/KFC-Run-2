using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaccasSpawner : MonoBehaviour
{
    public GameObject maccasSpawnPoint;

    private int position = 0;  // keeps track of position to place spawn point at
    public float spawnChance = 10;  // 0 = 0/10 chance, 10 = 10/10 chance

    void Start()
    {
        for (int i = 0; i < 30; i++)  // 30 chances to place spawner - every 22 z units
        {
            position = i * 22;

            if (Random.Range(0f, 10f) < spawnChance)
                Instantiate(maccasSpawnPoint, new Vector3(0, 0, position), Quaternion.identity);
        }
        
    }
}
