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

    public static void PlaySound(Sound sound)
    {
        GameObject gameObject = new GameObject("Sound", typeof(AudioSource));
        AudioSource audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.PlayOneShot(GetAudioClip(sound));
    }

    private static AudioClip GetAudioClip(Sound sound)
    {
        foreach(GameManager.SoundAudioClip soundAudioClip in GameManager.Instance.soundAudioClips)
        {
            if(soundAudioClip.sound == sound)
                return soundAudioClip.audioClip;
        }
        Debug.Log("Sound " + sound + " not found");
        return null;
    }
    
}