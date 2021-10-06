using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Guarda as configurações definidas na tela inicial do jogo
/// </summary>
public class Settings : MonoBehaviour {

	[Header("Sound")]
	[Range(0f,1f)]
	public float musicVolume = 1f;
	[Range(0f, 1f)]
	public float sfxVolume = 1f;

	[Header("Time")]
	[Tooltip("Seconds before the game starts")]
	public float startTime = 3f;
	[Tooltip("Play time before the game ends (in seconds)")]
	public float playTime = 180f;

	void Awake () {
		//DontDestroyOnLoad(gameObject);
		musicVolume = PlayerPrefs.GetFloat("musicVolume", 1f);
		sfxVolume = PlayerPrefs.GetFloat("sfxVolume", 1f);
		startTime = PlayerPrefs.GetFloat("startTime", 3f);
		playTime = PlayerPrefs.GetFloat("playTime", 180f);

	}

	public void AlterMusicVolume(float newVolume)
	{
		musicVolume = newVolume;
		PlayerPrefs.SetFloat("musicVolume", musicVolume);
		PlayerPrefs.Save();
	}

	public void AlterSoundVolume(float newVolume)
	{
		sfxVolume = newVolume;
		PlayerPrefs.SetFloat("sfxVolume", sfxVolume);
		PlayerPrefs.Save();
	}

	public void AlterStartTime (string newTime) {
		startTime = int.Parse(newTime);
		PlayerPrefs.SetFloat("startTime", startTime);
		PlayerPrefs.Save();
	}

	public void AlterPlayTime(string newTime)
	{
		playTime = int.Parse(newTime);
		PlayerPrefs.SetFloat("playTime", playTime);
		PlayerPrefs.Save();
	}
}
