using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Atualiza o texto de pontuação
/// </summary>
public class PointsText : MonoBehaviour {

	private Text txt;
	private PointManager pm;
	
	void OnEnable () {
		txt = GetComponent<Text>();

		pm = FindObjectOfType<PointManager>();
		UpdatePontos(pm.pontuacao);
	}
	
	void UpdatePontos (int pontos) {
		txt.text = pontos.ToString() + " points";
	}
}
