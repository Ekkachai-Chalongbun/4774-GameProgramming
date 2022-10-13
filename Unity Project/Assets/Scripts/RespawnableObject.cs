using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnableObject : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private PlayerAudioController audioController;
    [SerializeField] private float respawnDelay = 4f;
    [SerializeField] private ParticleSystem collectibleCollected;
    [SerializeField] private ParticleSystem collectibleSpawned;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        audioController.PlayCollectedSound();
        if (collision.CompareTag("Player"))
        {
            collectibleCollected.Play();
            spriteRenderer.enabled = false;
            StartCoroutine(RespawnPickable());
        }
    }

    public IEnumerator RespawnPickable()
    {
        yield return new WaitForSeconds(respawnDelay);
        spriteRenderer.enabled = true;
        audioController.PlayRespawnSound();
        collectibleSpawned.Play();
    }
}
