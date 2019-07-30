using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    
    [SerializeField]
    private AudioClip collectSound;

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
        // TODO
    }

    void PlaySound()
    {
        AudioManager.Instance.PlaySound(collectSound);
    }


}
