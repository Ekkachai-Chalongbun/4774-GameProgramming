using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnableObject : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;

    [SerializeField] private float respawnDelay = 4f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            spriteRenderer.enabled = false;
            StartCoroutine(RespawnPickable());
        }
    }

    public IEnumerator RespawnPickable()
    {
        yield return new WaitForSeconds(respawnDelay);
        spriteRenderer.enabled = true;
    }
}
