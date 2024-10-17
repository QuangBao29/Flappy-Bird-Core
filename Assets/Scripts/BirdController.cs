using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    public float gravityCo;
    private Vector2 velocity;
    public float jumpForce;
    public float jumpCD = 0.5f;
    public float lastJump = 0f;

    private void Awake()
    {
        Application.targetFrameRate = 60;
    }
    void Start()
    {
        
    }

    void Update()
    {
        velocity.y += gravityCo * Time.deltaTime;
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && Time.time > jumpCD + lastJump)
        {
            Debug.LogError("on click back key");
            velocity.y = jumpForce;
            lastJump = Time.time;
        }

        transform.position += new Vector3(0, velocity.y * Time.deltaTime, 0);
    }
}
