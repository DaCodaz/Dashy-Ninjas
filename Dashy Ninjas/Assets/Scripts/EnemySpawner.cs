using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    public GameObject enemy;
    public Transform spawnPoint;
    public float spawnTime = 10;

    void Start()
    {
        StartCoroutine(spawn());
    }
    IEnumerator spawn()
    {
        yield return new WaitForSeconds(spawnTime);
        Instantiate(enemy, spawnPoint);
    }
}
