using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script base da vida. Os scripts de vida das personagens herdam  as funcionalidades deste
/// </summary>
public class Vida : MonoBehaviour {

	[SerializeField]
	protected int maxVida = 3;
	public int vida { get; protected set; }
	
    private void Awake()
    {
        vida = maxVida;
    }

	public void AlteraVida(int qtd)
    {
        vida += qtd;

        if (vida > maxVida) vida = maxVida;
        else if (vida <= 0) Die();
    }

    protected virtual void Die()
    {
        print("ded");
    }
}
