using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Item de vida dropado por inimigos. Quando player entra em contato regenera sua vida
/// </summary>
public class DropVida : MonoBehaviour {

    [SerializeField] private int vida = 1;

    private Pooler pool;

    void Start()
    {
        pool = GameObject.Find("HealthPool").GetComponent<Pooler>();
    }
    private void OnTriggerEnter(Collider other)
    {
        VidaPlayer vp = other.GetComponent<VidaPlayer>();
        if (vp == null) return;
        vp.AlteraVida(vida);

        FindObjectOfType<AudioManager>().Play("PickUp");

        pool.FreeObject(gameObject);
    }
}
