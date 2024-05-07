using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Level7 : MonoBehaviour
{
    [SerializeField] Maccas maccas;
    [SerializeField] ColonelSanders colonel;
    [SerializeField] MaccasSpawner spawner;
    [SerializeField] GameObject spikes;

    private int MValue;
    private int SValue;
    private int CValue;

    // used to reference moving spikes objects to change ai
    private MovingSpikes ms;

    private int difficulty;

    void Start()
    {
        // read ai values
        StreamReader reader = new StreamReader("ai.dat");
        MValue = int.Parse(reader.ReadLine());
        SValue = int.Parse(reader.ReadLine());
        CValue = int.Parse(reader.ReadLine());
        reader.Close();

        // maccas ai
        maccas.deathTime = 0.5f + 0.125f * (20 - MValue);
        spawner.spawnChance = MValue / 4;

        // spikes ai
        foreach (Transform s in spikes.transform)
        {
            ms = s.GetComponent<MovingSpikes>();
            ms.hiddenTime = 0.1f + 0.1f * (20 - SValue);
        }

        // colonel ai
        difficulty = CValue / 5;
        if (difficulty == 0)
            difficulty = 1;

        difficulty--;

        colonel.difficulty = difficulty;
            
    }
}
