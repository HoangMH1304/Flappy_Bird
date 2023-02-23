using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
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
    private static SoundManager instance;

    public static SoundManager Instance { get => instance; }

    private void Awake() {
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

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
        Debug.Log("Sound " + sound + " not found");
        return null;
    }
}
