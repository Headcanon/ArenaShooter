using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Vida do inimigo. Quando morre da pontos para player e dropa um item
/// </summary>
public class VidaInimigo : Vida {

    protected override void Die()
    {
        AlteraVida(maxVida);

        EnemyData enemy = GetComponent<EnemyData>();        
        enemy.spawnData.currentEnemies--;

        // Pega uma pool aleatória dentre duas opções
        string pool = ((Random.value > .5f) ? "AmmoPool" : "HealthPool");

        Pooler dropPool = GameObject.Find(pool).GetComponent<Pooler>();
        GameObject go = dropPool.GetObject();
        go.transform.position = transform.position;
        go.SetActive(true);

        PointManager pm = FindObjectOfType<PointManager>();
        pm.Pontuar(enemy.valorPontos);


        enemy.spawnData.pool.FreeObject(gameObject);
    }
}
