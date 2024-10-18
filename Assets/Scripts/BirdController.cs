using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    private float gravityCo = Define.gravityCoe;
    private float jumpForce = Define.jumpForce;
    private float jumpCD = Define.jumpCoolDown;
    private float lastJump = 0f;

    private Vector2 velocity;

    private float birdRadius;
    private float pipeWidth;

    public float groundHeight;

    public Pipe currentPipe;

    private void Awake()
    {
        Application.targetFrameRate = 60;
    }
    void Start()
    {
        var sprite = GetComponent<SpriteRenderer>();
        float width = sprite.bounds.size.x;
        float height = sprite.bounds.size.y;
        birdRadius = Mathf.Max(width, height) / 2f;
        Debug.LogError("radius:" + birdRadius);
    }

    void Update()
    {
        //tap to fly
        velocity.y += gravityCo * Time.deltaTime;
        if (lastJump < jumpCD)
        {
            lastJump += Time.deltaTime;
        }
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && Time.time > jumpCD + lastJump)
        {   
            velocity.y = jumpForce;
            lastJump = 0f;
        }
        transform.position += new Vector3(0, velocity.y * Time.deltaTime, 0);

        //check collider
        //CheckColliderWithGround();
        CheckColliderWithPipes();
    }

    private void CheckColliderWithGround()
    {
        if (transform.position.y - birdRadius < groundHeight)
        {

        }
    }
    
    private void CheckColliderWithPipes()
    {
        var birdPos = transform.position;
        var pipeSize = currentPipe.pipeSprite.bounds.size;
        var topPipePos = currentPipe.topPipe.transform.position;
        //Debug.LogError("top pipe pos: " + topPipePos.x + " " + topPipePos.y);
        var botPipePos = currentPipe.botPipe.transform.position;
        //Debug.LogError("bot pipe pos: " + botPipePos.x + " " + botPipePos.y);

        if (birdPos.x + birdRadius >= topPipePos.x - pipeSize.x / 2 &&
            birdPos.x + birdRadius <= topPipePos.x + pipeSize.x / 2 &&
            birdPos.y + birdRadius >= topPipePos.y - pipeSize.y / 2)
        {
            Debug.LogError("collider with top pipe");
        }

        if (birdPos.x + birdRadius >= botPipePos.x - pipeSize.x / 2 &&
            birdPos.x + birdRadius <= botPipePos.x + pipeSize.x / 2 &&
            birdPos.y - birdRadius <= botPipePos.y + pipeSize.y / 2)
        {
            Debug.LogError("collider with bot pipe");
        }
    }
}
