using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Muda a textura da armadura aleatoriamente quando enemy spawna
/// </summary>
public class RandomArmor : MonoBehaviour {

	[SerializeField] private Material[] materiais;

	private Renderer rend;

	
	void OnEnable()
    {
		if (materiais.Length <= 0) return;

		rend = GetComponent<Renderer>();
		rend.material = materiais[Random.Range(0, materiais.Length - 1)];
    }
}
