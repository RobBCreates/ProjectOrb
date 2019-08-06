using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    
    [SerializeField]
    private AudioClip collectSound = null;
    [SerializeField]
    private GameObject explosion = null;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            DestroySelf();
        }
    }

    private void DestroySelf()
    {
        GameManager.Instance.CollectableDestroyed();
        PlayEffect();
        PlaySound();

        Destroy(gameObject);
    }

    void PlayEffect()
    {
        Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
        GameManager.Instance.PlayVibrate();
    }

    void PlaySound()
    {
        // Handled in AudioManager so that we can Destroy(gameObject).
        AudioManager.Instance.PlaySound(collectSound);
    }


}
