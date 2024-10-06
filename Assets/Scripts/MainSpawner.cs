using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSpawner : MonoBehaviour
{
    [SerializeField] private List<EnemySpawner> _spawners;

    [SerializeField] private float _repeatRate = 2.0f;

    private void Start()
    {
        SelectSpawnPoint();
    }

    private void SelectSpawnPoint()
    {
        StartCoroutine(DelayedLaunch());
    }

    private IEnumerator DelayedLaunch()
    {
        while (true)
        {
            yield return new WaitForSeconds(_repeatRate);
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        int randomSpawnerNumber = Random.Range(0, _spawners.Count);
        _spawners[randomSpawnerNumber].Spawn();
    }
}
