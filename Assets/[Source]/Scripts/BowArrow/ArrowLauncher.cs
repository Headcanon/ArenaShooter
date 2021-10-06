using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Atira projeteis do tipo Arrow. Usada tanto por Player quanto por Archer Enemies
/// </summary>
public class ArrowLauncher : MonoBehaviour {

	[Header("Ammo Info")]
	[SerializeField] private int maxAmmo = 3;
	[SerializeField] private bool infinite = false;
	private int ammo = 3;

	[Header("Launch Info")]
	[SerializeField] private Transform launchPoint;
	[SerializeField] private float launchForce = 500f;
	[SerializeField] private float despawnTime = 5f;

	private Pooler pool;

	private void Start()
    {
		pool = GameObject.Find("ArrowPool").GetComponent<Pooler>();
		ammo = maxAmmo;
    }

	public void Launch()
    {
		// Cuida da munição
		if (ammo == 0) return;
		if(!infinite) ammo--;

		// Spawna a flecha na posição adequada
		GameObject go = pool.GetObject();
		go.SetActive(true);
		go.transform.position = launchPoint.position;
		go.transform.rotation = launchPoint.rotation;

		// Lança a flecha com física
		Rigidbody rb = go.GetComponent<Rigidbody>();
		rb.AddForce(transform.forward * launchForce);

		// Ativa a flecha
		Arrow arrow = go.GetComponent<Arrow>();
		arrow.Launch(despawnTime);

		// Som de atirar
		GetComponent<AudioSource>().Play();
	}

	// Recarrega a munição se for menor que o máximo
	public void Reload(int load)
    {
		if(ammo + load <= maxAmmo)
        {
			ammo += load;
        }
		else
        {
			ammo = maxAmmo;
        }
    }
}
