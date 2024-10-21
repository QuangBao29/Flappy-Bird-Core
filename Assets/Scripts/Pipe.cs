using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    [SerializeField]
    private GameObject topPipe = null;
    [SerializeField]
    private GameObject botPipe = null;
    [SerializeField]
    private Sprite pipeSprite = null;

    public GameObject TopPipe
    { get { return topPipe; } }

    public GameObject BotPipe 
    { get { return botPipe; } }

    public Sprite PipeSprite
    { get { return pipeSprite; } }

    private float pipeSpeed = Define.pipeSpeed;

    void Update()
    {
        transform.position += new Vector3(-pipeSpeed * Time.deltaTime, 0, 0);

        if (transform.position.x <= GameController.Instance.despawnPipePosition.transform.position.x)
        {
            if (!PipeController.Instance.RemoveDespawnPipeFromList(this))
            {
                Debug.LogError("failed to remove pipe!");
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    public void OnSetGameOverState()
    {
        pipeSpeed = 0f;
    }
}
