using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioController : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private SoAudioClips walkAudioClips;
    [SerializeField] private SoAudioClips jumpAudioClips;
    [SerializeField] private SoAudioClips jumppadAudioClips;
    [SerializeField] private SoAudioClips collectibleCollectedAudioClips;
    [SerializeField] private SoAudioClips collectibleRespawnAudioClips;
    [SerializeField] private SoAudioClips deathAudioClips;
    [SerializeField] private SoAudioClips fallAudioClips;
    [SerializeField] private SoAudioClips winningAudioClips;

    public void PlayJumpSound()
    {
        audioSource.PlayOneShot(jumpAudioClips.GetAudioClip(), 0.5f);
    }

    public void PlayWalkSound()
    {
        audioSource.PlayOneShot(walkAudioClips.GetAudioClip(), 0.5f);
    }

    public void PlayJumpPadSound()
    {
        audioSource.PlayOneShot(jumppadAudioClips.GetAudioClip(), 0.5f);
    }

    public void PlayCollectedSound()
    {
        audioSource.PlayOneShot(collectibleCollectedAudioClips.GetAudioClip(), 0.5f);
    }

    public void PlayRespawnSound()
    {
        audioSource.PlayOneShot(collectibleRespawnAudioClips.GetAudioClip(), 0.5f);
    }

    public void PlayDeathSound()
    {
        audioSource.PlayOneShot(deathAudioClips.GetAudioClip(), 2f);
    }

    public void PlayFallSound()
    {
        audioSource.PlayOneShot(fallAudioClips.GetAudioClip(), 0.5f);
    }

    public void PlayWinningSound()
    {
        audioSource.PlayOneShot(winningAudioClips.GetAudioClip(), 0.5f);
    }
}
