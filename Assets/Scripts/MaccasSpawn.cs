using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaccasSpawn : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Maccas maccas;
    [SerializeField] GameObject maccasObj;
    [SerializeField] GameObject text;

    private int spawnDistance = 50;

    void Update()
    {
        if (player.position.z >= transform.position.z)
        {
            maccasObj.SetActive(true);
            maccasObj.transform.position = new Vector3(Random.Range(-25, 34), transform.position.y, transform.position.z + spawnDistance);
            maccas.kill = true;
            text.SetActive(true);

            // fix bug where text remains after killing maccas
            if (!maccasObj.activeSelf)
                text.SetActive(false);

            // get rid of spawn point
            Destroy(gameObject);
        }
    }
}
