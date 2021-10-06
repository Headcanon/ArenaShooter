using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Projétil que causa dano quando colide. Desaparece após um tempo determinado
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class Arrow : MonoBehaviour {

    [SerializeField] private int dano = 1;

    private Pooler pool;

    private void Start()
    {
        pool = transform.parent.GetComponent<Pooler>();
    }

    // Despawna a flecha após um tempo determinado
    public void Launch(float despawnTime)
    {
        StartCoroutine(DespawnAfterTime(despawnTime));
    }
    IEnumerator DespawnAfterTime(float tempoDespawn)
    {
        yield return new WaitForSeconds(tempoDespawn);
        pool.FreeObject(gameObject);
    }

    // Causa dano
    private void OnCollisionEnter(Collision collision)
    {
        Vida v = collision.gameObject.GetComponent<Vida>();
        if(v != null)
        {
            v.AlteraVida(-dano);
        }
    }
}
