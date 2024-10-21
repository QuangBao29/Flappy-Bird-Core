using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private static GameController instance;

    public GameObject spawnPipePosition;
    public GameObject despawnPipePosition;
    public GameObject ground;
    public GameObject gameOverPanel;
    public BirdController bird;
    public PipeController pipeController;

    public static GameController Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameController>();
                if (instance == null)
                {
                    Debug.LogError("cannot find object of type Game Controller");
                    return null;
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        Application.targetFrameRate = 60;
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        gameOverPanel.SetActive(false);
    }

    public void OnGameOverTrigger()
    {
        gameOverPanel.SetActive(true);
        bird.OnSetGameOverState();
        pipeController.OnSetGameOverState();
    }

    public void OnRestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
