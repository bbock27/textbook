using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{


    public GameObject enemyPrefab;
    public float startTime;
    public float endTime;
    public float spawnRate;
    // Start is called before the first frame update
    void Start()
    {
        WavesManager.instance.AddWave(this);
        InvokeRepeating("Spawn", startTime, spawnRate);
        Invoke("EndSpawner", endTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void EndSpawner()
    {
        WavesManager.instance.RemoveWave(this);
        CancelInvoke();
    }

    void Spawn(){
        Instantiate(enemyPrefab, transform.position, transform.rotation);
    }
}
