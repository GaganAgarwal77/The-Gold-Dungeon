using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpCoin : MonoBehaviour
{
    [SerializeField] AudioClip coinPickupSound;
    [SerializeField] int scoreToAdd = 100;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<GameSession>().IncreaseScore(scoreToAdd);
        //FindObjectOfType<ScenePersist>().RemoveCoin();
        AudioSource.PlayClipAtPoint(coinPickupSound, Camera.main.transform.position);
        Destroy(gameObject);
    }
  
}
