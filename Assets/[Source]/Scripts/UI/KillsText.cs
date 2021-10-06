using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Atualiza o texto de kills
/// </summary>
public class KillsText : MonoBehaviour {

	private Text txt;
	private PointManager pm;

	void OnEnable()
	{
		txt = GetComponent<Text>();

		pm = FindObjectOfType<PointManager>();
		UpdateKills(pm.kills);
	}

	void UpdateKills(int pontos)
	{
		txt.text = pontos.ToString() + " kills";
	}
}
