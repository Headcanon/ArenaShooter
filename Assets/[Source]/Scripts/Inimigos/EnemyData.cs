using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Dados sobre o inimigo
/// </summary>
public class EnemyData : MonoBehaviour {

	public int valorPontos = 15;

	[HideInInspector] public EnemySpawnData spawnData;
}
