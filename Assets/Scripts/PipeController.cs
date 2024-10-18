using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour
{
    [SerializeField]
    private Pipe pipePrefab = null;
    [SerializeField]
    private BirdController bird = null;
    public List<Pipe> pipesList = new List<Pipe>();

    private float spawnCD = Define.pipeSpawnCD;
    private float lastSpawn = Define.pipeSpawnCD;
    
    private static PipeController instance;

    public static PipeController Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<PipeController>();
                if (instance == null)
                {
                    Debug.LogError("cannot find object of type Pipe Controller");
                    return null;
                }
            }
            return instance;
        }
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        
    }
    private void Update()
    {
        if (lastSpawn >= spawnCD)
        {
            SpawnPipes();
            bird.currentPipe = GetNearestPipe();
            lastSpawn = 0f;
        }
        else
        {
            lastSpawn += Time.deltaTime;
        }
    }

    public void SpawnPipes()
    {
        if (pipePrefab != null)
        {
            var newPipe = Utils.InstantiateObject<Pipe>(pipePrefab, null);
            newPipe.transform.position = GameController.Instance.spawnPipePosition.transform.position;
            newPipe.transform.position += new Vector3(0, newPipe.transform.position.y + Utils.RandomInt(-12, 6), 0);
            newPipe.gameObject.SetActive(true);
            pipesList.Add(newPipe);
        }
    }

    public bool RemoveDespawnPipeFromList(Pipe target)
    {
        if (pipesList.Contains(target))
        {
            pipesList.Remove(target);
            return true;
        }
        return false;
    }

    private Pipe GetNearestPipe()
    {
        float nearest = Mathf.Infinity;
        Pipe nearestPipe = null;
        foreach (var pipe in pipesList)
        {
            if (pipe.transform.position.x > bird.transform.position.x)
            {
                float distance = pipe.transform.position.x - bird.transform.position.x;
                if (distance < nearest)
                {
                    nearest = distance;
                    nearestPipe = pipe;
                }
            }
        }
        return nearestPipe;
    }
}
