using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    [SerializeField]
    private TMP_Text scoreText;
    [SerializeField]
    private TMP_Text finalScoreText;

    private int scoreCount = 0;

    public void IncreaseScore()
    {
        scoreCount++;
        scoreText.text = scoreCount.ToString();
    }

    public void OnSetGameOverState()
    {
        finalScoreText.text = "Final Score: " + scoreText.text;
        scoreText.gameObject.SetActive(false);
    }
}
