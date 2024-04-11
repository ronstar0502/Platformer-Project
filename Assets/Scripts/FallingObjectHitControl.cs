using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObjectHitControl : MonoBehaviour
{
    private PlayerController player;

    private void Awake()
    {
        player = FindObjectOfType<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerCollision(collision);
        if (collision.CompareTag("DestroyZone"))
        {
            Destroy(this.gameObject);
        }
    }

    private void PlayerCollision(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (this.CompareTag("ScoreObject"))
            {
                player.transform.localScale *= player.scaleUpIncrement;
                player.UpdateScore(player.score + 1);
            }
            else
            {
                player.transform.localScale *= player.scaleDownIncrement;
                player.UpdateHealth();
            }

            Destroy(this.gameObject);
        }
    }
}
