using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Lista de possíveis pontos estratégicos para inimigos do tipo Archer
/// </summary>
public class ArcherSpots : MonoBehaviour {

	public Transform[] spots;

	public static ArcherSpots instance;

	private void Awake()
    {
		instance = this;
    }

	public Transform GetRandomSpot()
    {
		return spots[Random.Range(0, spots.Length - 1)];
    }
}
