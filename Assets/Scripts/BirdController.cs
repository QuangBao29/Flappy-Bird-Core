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
    private float columnWidth;

    public float groundHeight;
    private void Awake()
    {
        Application.targetFrameRate = 60;
    }
    void Start()
    {
        var sprite = GetComponent<SpriteRenderer>();
        float width = sprite.bounds.size.x;
        float height = sprite.bounds.size.y;
        Debug.LogError("height: " + height + " width: " + width);
        birdRadius = Mathf.Max(width, height) / 2f;
    }

    void Update()
    {
        //tap to fly
        velocity.y += gravityCo * Time.deltaTime;
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && Time.time > jumpCD + lastJump)
        {
            velocity.y = jumpForce;
            lastJump = Time.time;
        }
        transform.position += new Vector3(0, velocity.y * Time.deltaTime, 0);

        //check collider

    }

    private void CheckColliderWithGround()
    {
        if (transform.position.y - birdRadius < groundHeight)
        {

        }
    }
    
    private void CheckColliderWithColumn()
    {
        if (transform.position.x + birdRadius >= columnWidth)
        {

        }
    }
}
