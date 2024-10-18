using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour
{
    [SerializeField]
    public Pipe pipePrefab;

    public List<Pipe> pipes = new List<Pipe>();

    public float spawnCD = 2f;
    private float lastSpawn = 0f;

    private void Update()
    {
        if (lastSpawn >= spawnCD)
        {

        }
    }
    public void SpawnPipes()
    {
        if (pipePrefab != null)
        {
            var newPipe = Utils.InstantiateObject<Pipe>(pipePrefab, null);
            pipes.Add(newPipe);
        }
    }
}
