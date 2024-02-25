using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObjectHitControl : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D collision)
    {    
        if (collision.CompareTag("Player"))
        {
            PlayerController player = collision.GetComponent<PlayerController>();
            if (this.CompareTag("ScoreObject"))
            {
                player.transform.localScale *= player.scaleUpIncrement;
            }
            if (this.CompareTag("Bomb"))
            {
                player.transform.localScale *= player.scaleDownIncrement;
            }
            Destroy(this.gameObject);
        }
        if (collision.CompareTag("DestroyZone"))
        {
            Destroy(this.gameObject);
        }
    }
}