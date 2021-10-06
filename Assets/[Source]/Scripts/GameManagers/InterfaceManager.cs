using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Centraliza as UIs para facilitar abrir e fechar cada uma delas
/// </summary>
public class InterfaceManager : MonoBehaviour {

    private InterfaceHolder gameHud;
    private InterfaceHolder deathMenu;
    private InterfaceHolder victoryMenu;
    private InterfaceHolder pauseMenu;

    private void Start()
    {
        gameHud = GameObject.Find("GameHudHolder").GetComponent<InterfaceHolder>();
        deathMenu = GameObject.Find("DeathMenuHolder").GetComponent<InterfaceHolder>();
        victoryMenu = GameObject.Find("VictoryMenuHolder").GetComponent<InterfaceHolder>();
        pauseMenu = GameObject.Find("PauseMenuHolder").GetComponent<InterfaceHolder>();
    }

    public void Die() { OpenMenu(deathMenu); }

    public void Pause() { OpenMenu(pauseMenu); }

    public void Unpause() { CloseMenu(pauseMenu); }

    public void Victory() { OpenMenu(victoryMenu); }

    private void OpenMenu(InterfaceHolder ih)
    {
        Time.timeScale = 0;
        ih.ShowInterface();
        gameHud.HideInterface();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void CloseMenu(InterfaceHolder ih)
    {
        Time.timeScale = 1;
        ih.HideInterface();
        gameHud.ShowInterface();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
