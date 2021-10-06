using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Caixa que spawna munição dentro de seu volume
/// </summary>
[RequireComponent(typeof(BoxCollider))]
public class AmmoSpawner : MonoBehaviour
{
    [SerializeField] private Pooler ammoPool;
    [SerializeField] private float maxSpawnTime = 15;

    private Bounds bounds;
    private TimeManager time;
    private float timer;

    void Start()
    {
        bounds = GetComponent<Collider>().bounds;
        time = FindObjectOfType<TimeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(time.playing)
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                SpawnAmmo();
                timer = maxSpawnTime;
            }
        }
    }

    private void SpawnAmmo()
    {
        GameObject go = ammoPool.GetObject();
        if(go != null)
        {
            go.transform.position = bounds.GetRandomPoint();
            go.SetActive(true);
        }
    }
}
