using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    public float pipeSpeed;
    public Sprite pipeSprite;

    public GameObject topPipe;
    public GameObject botPipe;

    void Start()
    {

    }

    void Update()
    {
        transform.position += new Vector3(-pipeSpeed * Time.deltaTime, 0, 0);
    }
}
