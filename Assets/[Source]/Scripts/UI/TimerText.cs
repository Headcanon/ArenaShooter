using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Atualiza o texto do timer a cada segundo
/// </summary>
public class TimerText : MonoBehaviour {

	private Text txt;
	private TimeManager tm;

	void Start () {
		txt = GetComponent<Text>();

		tm = FindObjectOfType<TimeManager>();
		tm.secondPassed += UpdateTimer;
	}
	
	// Update is called once per frame
	void UpdateTimer (float currentTime) {
		txt.text = currentTime.ToString();
	}
}
