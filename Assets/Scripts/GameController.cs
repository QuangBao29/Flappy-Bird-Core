using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public GameObject spawnPipePosition;
    public GameObject endPipePosition;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        
    }
}
