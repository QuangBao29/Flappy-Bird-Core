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
    private float groundHeight;
    private bool isBirdAlive = true;

    public Pipe currentPipe = null;

    void Start()
    {
        var sprite = GetComponent<SpriteRenderer>();
        float width = sprite.bounds.size.x;
        float height = sprite.bounds.size.y;
        birdRadius = Mathf.Min(width, height) / 2f;

        groundHeight = GameController.Instance.ground.transform.position.y + 
            GameController.Instance.ground.GetComponent<SpriteRenderer>().bounds.size.y/2;
    }

    void Update()
    {
        if (GameController.Instance.IsGameStarted)
        {
            //tap to fly
            velocity.y += gravityCo * Time.deltaTime;
            if (lastJump < jumpCD)
            {
                lastJump += Time.deltaTime;
            }
            if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && (Time.time > jumpCD + lastJump) && isBirdAlive)
            {
                velocity.y = jumpForce;
                lastJump = Time.time;
            }
            transform.position += new Vector3(0, velocity.y * Time.deltaTime, 0);

            //check collider
            CheckColliderWithGround();
            CheckColliderWithPipes();
        }
    }

    private void CheckColliderWithGround()
    {
        if (transform.position.y - birdRadius < groundHeight)
        {
            GameController.Instance.OnGameOverTrigger();
        }
    }
    
    private void CheckColliderWithPipes()
    {
        if (currentPipe != null)
        {
            var birdPos = transform.position;
            var pipeSize = currentPipe.PipeSprite.bounds.size;
            var topPipePos = currentPipe.TopPipe.transform.position;
            var botPipePos = currentPipe.BotPipe.transform.position;

            if (birdPos.x + birdRadius >= topPipePos.x - pipeSize.x / 2 &&
                birdPos.x + birdRadius <= topPipePos.x + pipeSize.x / 2 &&
                birdPos.y + birdRadius >= topPipePos.y - pipeSize.y / 2)
            {
                GameController.Instance.OnGameOverTrigger();
            }

            if (birdPos.x + birdRadius >= botPipePos.x - pipeSize.x / 2 &&
                birdPos.x + birdRadius <= botPipePos.x + pipeSize.x / 2 &&
                birdPos.y - birdRadius <= botPipePos.y + pipeSize.y / 2)
            {
                GameController.Instance.OnGameOverTrigger();
            }
        }
    }

    public void OnSetGameOverState()
    {
        isBirdAlive = false;
        velocity.y = 0f;
        gravityCo = 0f;
    }
}
