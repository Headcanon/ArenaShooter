using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Faz a contagem de tempo dentro do jogo
/// </summary>
public class TimeManager : MonoBehaviour {

    [Tooltip("Seconds before the game starts")]
    [SerializeField] private float startTimer = 3f;
    [Tooltip("Play time before the game ends (in seconds)")]
    [SerializeField] private float playTimer = 180f;

    public bool playing { get; private set; }
    public float CurrentTimer { get; private set; }
    public event Action<float> secondPassed;

    private void Start()
    {
        Settings c = FindObjectOfType<Settings>();
        if (c != null)
        {
            startTimer = c.startTime;
            playTimer = c.playTime;
        }
        CurrentTimer = startTimer;

        StartCoroutine(Counter());
    }
        
    // Lógica de cada segundo
    IEnumerator Counter()
    {
        yield return new WaitForSeconds(1f);
        if (secondPassed != null) secondPassed(CurrentTimer);
        
        if (CurrentTimer > 0)
        {
            CurrentTimer--;

            StartCoroutine(Counter());
        }
        else ManageTimer();
    }

    // Alterna entre os dois timers
    private void ManageTimer()
    {
        if(!playing)
        {
            playing = true;
            CurrentTimer = playTimer;

            StartCoroutine(Counter());
        }
        else
        {
            GetComponent<InterfaceManager>().Victory();
        }
    }
}
