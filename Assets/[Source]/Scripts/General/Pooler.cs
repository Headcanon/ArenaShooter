using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Cria e administra pools de objetos.
/// </summary>
public class Pooler : MonoBehaviour {

	[SerializeField]
	private GameObject prefab;
	[SerializeField]
	private int tamanhoInicial = 3;
	[SerializeField] 
	private bool expandable = false;

	private List<GameObject> freeList;
	private List<GameObject> usedList;

	void Awake () {
		freeList = new List<GameObject>();
		usedList = new List<GameObject>();

		for(int i =0; i < tamanhoInicial; i++)
        {
			GenerateNewObject();
        }
	}

    private void GenerateNewObject()
    {
		GameObject go = Instantiate(prefab);
		go.transform.parent = transform;
		go.SetActive(false);

		freeList.Add(go);
    }

    public GameObject GetObject()
    {
		if (freeList.Count == 0 && !expandable) return null;
		else if (freeList.Count == 0) GenerateNewObject();

		GameObject go = freeList[freeList.Count - 1];
		freeList.RemoveAt(freeList.Count - 1);
		usedList.Add(go);

		return go;
    }

	public void FreeObject(GameObject go)
    {
		Debug.Assert(usedList.Contains(go));

		go.SetActive(false);
		go.transform.parent = transform;

		usedList.Remove(go);
		freeList.Add(go);
	}
}
