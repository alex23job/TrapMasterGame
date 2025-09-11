using NUnit.Framework;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    private GameObject enemyPrefab;
    private List<Vector3> path = new List<Vector3>();
    private float spawnDelay = 0;
    private float timer;
    private bool isPause = false;
    private Vector3 spawnPosition = Vector3.zero;

    public Vector3 SpawnPos { get => spawnPosition; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPause == false)
        {
            if (timer > 0) timer -= Time.deltaTime;
            else
            {
                timer = spawnDelay;
                Spawn();
            }
        }
    }

    public void SetPrefab(GameObject prefab)
    {
        enemyPrefab = prefab;
        if (spawnPosition == Vector3.zero)
        {
            spawnPosition = transform.parent.position;
            spawnPosition.x += transform.localPosition.x;
            spawnPosition.z += transform.localPosition.z;
            print($"SpawnPos={SpawnPos}");
        }
    }

    public void TranslatePath(List<Vector3> newPath)
    {
        path = newPath;
        /*StringBuilder sb = new StringBuilder();
        for (int i = 0; i < path.Count; i++) sb.Append($"<{path[i]}> ");
        print( sb.ToString() );*/
    }

    public void SetDelaySpawn(float delay)
    {
        spawnDelay = delay;
        timer = spawnDelay;
    }

    public void SetPause(bool pause)
    {
        isPause = pause;
    }

    private void Spawn()
    {
        GameObject enemy = Instantiate(enemyPrefab, transform.position, transform.rotation);
        enemy.GetComponent<EnemyMovement>().SetPath(path);
    }
}
