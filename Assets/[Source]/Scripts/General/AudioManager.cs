using UnityEngine.Audio;
using UnityEngine;
using System;

/// <summary>
/// Administra os sons 2D do jogo
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour {

	[SerializeField]
	private Sound[] sfxArray;

	private AudioSource music;
	private Settings settings;

	void Start () {
		settings = FindObjectOfType<Settings>();
		music = GetComponent<AudioSource>();

        foreach (Sound s in sfxArray)
        {
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;
        }
	}
	
	void Update () {

		if (settings == null) return;

		music.volume = settings.musicVolume;
		foreach (Sound s in sfxArray)
		{
			s.source.volume = s.volume * settings.sfxVolume;
		}
	}

	public void Play(string name)
    {
		Sound s = Array.Find(sfxArray, sound => sound.name == name);
		if (s == null) return;
		s.source.Play();
    }
}

/// <summary>
/// Guarda as informações de um clipe de som
/// </summary>
[System.Serializable]
public class Sound
{
	public string name;
	public AudioClip clip;
	[Range(0f, 1f)]
	public float volume = 1f;

	[HideInInspector]
	public AudioSource source;
}
