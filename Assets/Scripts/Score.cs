using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    private PlayerController player;
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: "+player.score;
        }
    }
}
