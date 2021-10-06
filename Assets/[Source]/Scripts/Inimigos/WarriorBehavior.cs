using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Comportamento do inimigo do tipo Warrior
/// </summary>
public class WarriorBehavior : MonoBehaviour
{
	[SerializeField] private int dano = 1;
	[SerializeField] private Transform attackPoint;
	[SerializeField] private float damageRange = 2f;

	private Transform player;
	private NavMeshAgent agent;
	private Animator anim;

	// Use this for initialization
	void Start()
	{
		player = FindObjectOfType<VidaPlayer>().transform;
		agent = GetComponent<NavMeshAgent>();
		anim = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update()
	{
		agent.SetDestination(player.position);
		if (Vector3.Distance(transform.position, player.position) <= agent.stoppingDistance)
		{
			anim.SetBool("Attack", true);
		}
		else
		{
			anim.SetBool("Attack", false);
		}
	}

	// Método que ataca, chamado através de um animation event
	private void Hit()
	{
		GetComponent<AudioSource>().Play();

		Collider[] cols = Physics.OverlapSphere(attackPoint.position, damageRange);

		foreach (Collider c in cols)
		{
			if (c.CompareTag("Player"))
			{
				Vida v = c.GetComponent<Vida>();
				v.AlteraVida(-dano);

				FindObjectOfType<AudioManager>().Play("Hit");
			}
		}
	}
}
