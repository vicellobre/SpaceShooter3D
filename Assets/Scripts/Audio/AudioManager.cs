using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The audio manager
/// </summary>
public static class AudioManager
{
    static bool initialized = false;
    static AudioSource audioSource;
    static Dictionary<AudioClipName, AudioClip> audioClips =
        new Dictionary<AudioClipName, AudioClip>();

    /// <summary>
    /// Gets whether or not the audio manager has been initialized
    /// </summary>
    public static bool Initialized => initialized;

    /// <summary>
    /// Initializes the audio manager
    /// </summary>
    /// <param name="source">audio source</param>
    public static void Initialize(AudioSource source)
    {
        initialized = true;
        audioSource = source;
        audioClips.Add(AudioClipName.Explosion_Asteroid, Resources.Load<AudioClip>("Audios/explosion_asteroid"));
        audioClips.Add(AudioClipName.Explosion_Enemy, Resources.Load<AudioClip>("Audios/explosion_enemy"));
        audioClips.Add(AudioClipName.Explosion_Player, Resources.Load<AudioClip>("Audios/explosion_player"));
        audioClips.Add(AudioClipName.Music_Background, Resources.Load<AudioClip>("Audios/music_background"));
        audioClips.Add(AudioClipName.Weapon_Enemy, Resources.Load<AudioClip>("Audios/weapon_enemy"));
        audioClips.Add(AudioClipName.Weapon_Player, Resources.Load<AudioClip>("Audios/weapon_player"));
    }

    /// <summary>
    /// Plays the audio clip with the given name
    /// </summary>
    /// <param name="name">name of the audio clip to play</param>
    public static void Play(AudioClipName name)
    {
        audioSource.PlayOneShot(audioClips[name]);
    }
}