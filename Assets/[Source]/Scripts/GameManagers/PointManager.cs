using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Contagem de kills e de pontos
/// </summary>
public class PointManager : MonoBehaviour {
    public int pontuacao { get; private set; }
    public int kills { get; private set; }

    public void Pontuar(int pontos)
    {
        kills++;
        pontuacao += pontos;
    }
}
