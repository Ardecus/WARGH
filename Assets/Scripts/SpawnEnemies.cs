using UnityEngine;
using System.Collections.Generic;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] private List<Transform> SpawnPoints;
    [SerializeField] private GameObject enemy;
    [SerializeField] private Transform enemies;

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Spawn();
        }
    }

    private void Spawn()
    {
        int index = Random.Range(0, SpawnPoints.Count);
        var spawned = (GameObject)Instantiate(enemy, SpawnPoints[index]);

        spawned.transform.SetParent(enemies, false);
        spawned.transform.SetAsLastSibling();
    }
}
