using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoSingleton<SoundManager>
{
    public enum Sound{
        wing,
        hit,
        point,
        die,
        swoosh
    }

    [SerializeField] private SoundAudioClip[] soundAudioClips;
    [SerializeField] private AudioSource audioSource;

    public void PlaySound(Sound sound)
    {
        audioSource.PlayOneShot(GetAudioClip(sound));
    }

    public AudioClip GetAudioClip(Sound sound)
    {
        foreach(SoundAudioClip soundAudioClip in soundAudioClips)
        {
            if(soundAudioClip.sound == sound)
                return soundAudioClip.audioClip;
        }
        Logger.Log("Sound " + sound + " not found");
        return null;
    }
}
