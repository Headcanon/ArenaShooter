using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Caixa que spawna inimigos dentro de seu volume
/// </summary>
[RequireComponent(typeof(BoxCollider))]
public class EnemySpawner : MonoBehaviour {

	[SerializeField] private List<EnemySpawnData> inimigos;

	private Bounds bounds;
	private TimeManager time;

	void Start () {
		bounds = GetComponent<Collider>().bounds;
		time = FindObjectOfType<TimeManager>();
	}
	
	void Update () {
		if (time.playing)
		{
			foreach (EnemySpawnData e in inimigos)
			{
				if (e.currentEnemies < e.maxEnemies)
				{
					StartCoroutine(SpawnEnemy(e));
					e.currentEnemies++;
				}
			}
		}
	}

	private IEnumerator SpawnEnemy(EnemySpawnData e)
    {
		yield return new WaitForSeconds(e.waitForSpawn);

		GameObject go = e.pool.GetObject();
		if (go != null)
		{
			go.transform.position = bounds.GetRandomPoint();
			go.SetActive(true);

			go.GetComponent<EnemyData>().spawnData = e;
		}
    }
}

/// <summary>
/// Dados sobre o spawn de cada tipo de inimigo
/// </summary>
[System.Serializable]
public class EnemySpawnData
{
	public int maxEnemies = 3;
	public float waitForSpawn = 1f;
	public Pooler pool;

	[HideInInspector] public int currentEnemies;
}