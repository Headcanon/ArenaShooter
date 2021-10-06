using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Métodos chamados por botões pra carregar cenas. 
/// </summary>
public class LoadManager : MonoBehaviour {

    public void ReturnToMainMenu()
    {
        SceneLoader.LoadScene("MenuScene");
    }

    public void LoadBattle()
    {
        Time.timeScale = 1;
        SceneLoader.LoadScene("BattleScene");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
