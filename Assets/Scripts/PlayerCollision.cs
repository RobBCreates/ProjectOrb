using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    [SerializeField]
    private AudioClip hitSound;

    private void OnCollisionEnter2D(Collision2D other)
    {
        DestroyPlayer();

    }

    void DestroyPlayer()
    {
        PlayEffect();
        PlaySound();

        // TODO - Call GameManager 

        Destroy(gameObject);

    }

    void PlaySound()
    {
        AudioManager.Instance.PlaySound(hitSound);
    }

    void PlayEffect()
    {

    }
}
