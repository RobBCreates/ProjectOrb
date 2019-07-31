using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    [SerializeField]
    private AudioClip hitSound;
    [SerializeField]
    private GameObject explosion;

    private void OnCollisionEnter2D(Collision2D other)
    {
        DestroyPlayer();

    }

    void DestroyPlayer()
    {
        PlayEffect();
        PlaySound();

        GameManager.Instance.PlayerDied();
        Destroy(gameObject);

    }

    void PlaySound()
    {
        AudioManager.Instance.PlaySound(hitSound);
    }

    void PlayEffect()
    {
        GameManager.Instance.PlayVibrate();
        Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
    }
}
