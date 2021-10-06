using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Cuida de carregar cenas, sempre passando pela tela de loading
/// </summary>
public class SceneLoader : MonoBehaviour {

	[SerializeField]
	private Slider slider;
		
	void Start () {
		string sceneName = PlayerPrefs.GetString("SCENE_TO_LOAD", "MenuScene");
		PlayerPrefs.SetString("SCENE_TO_LOAD", "MenuScene");
		PlayerPrefs.Save();

		slider.value = 0;
		StartCoroutine(LoadSceneAsync(sceneName));
	}

    private IEnumerator LoadSceneAsync(string sceneName)
    {
		System.GC.Collect();
		AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);

		while(!asyncOperation.isDone)
        {
			slider.value = asyncOperation.progress;
			yield return null;
        }
    }

	public static void LoadScene(string sceneName)
	{
		PlayerPrefs.SetString("SCENE_TO_LOAD", sceneName);
		PlayerPrefs.Save();
		SceneManager.LoadScene("LoadingScene");
	}
}
