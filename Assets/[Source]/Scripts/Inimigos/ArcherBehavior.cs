using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Comportamento do inimigo tipo Archer
/// </summary>
public class ArcherBehavior : MonoBehaviour
{
	private Transform player;
	private Transform strategicSpot;

	private NavMeshAgent agent;
	private Animator anim;
	private ArrowLauncher launcher;

	void Start()
	{
		strategicSpot = ArcherSpots.instance.GetRandomSpot();

		player = FindObjectOfType<VidaPlayer>().transform;

		agent = GetComponent<NavMeshAgent>();
		agent.SetDestination(strategicSpot.position);

		anim = GetComponent<Animator>();
		launcher = GetComponent<ArrowLauncher>();
	}

	private void OnEnable()
    {
		if(strategicSpot != null)
        {
			agent.SetDestination(strategicSpot.position);
		}
    }

	void Update()
	{
		if (Vector3.Distance(transform.position, strategicSpot.position) <= agent.stoppingDistance)
		{
			anim.SetBool("Running", false);
			anim.SetBool("Attacking", true);
			Look();
		}
		else
        {
			anim.SetBool("Running", true);
		}
	}

    private void Look()
    {
		float x = player.position.x;
		float z = player.position.z;
		float y = transform.position.y;
		transform.LookAt(new Vector3(x, y, z));
    }

	// Méto de atirar, chamado através de um animation event
	private void Hit()
    {
		launcher.Launch();
    }
}
