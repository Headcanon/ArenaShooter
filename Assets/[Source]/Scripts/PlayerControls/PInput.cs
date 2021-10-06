using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Escuta os inputs de player
/// </summary>
public class PInput : MonoBehaviour {

	[HideInInspector] public float mouseX;
	[HideInInspector] public float mouseY;
	[HideInInspector] public float moveX;
	[HideInInspector] public float moveY;
	[HideInInspector] public bool jump;

	private ArrowLauncher launcher;
	private InterfaceManager im;

	void Start () {
		launcher = GetComponent<ArrowLauncher>();
		im = FindObjectOfType<InterfaceManager>();
	}
	
	
	void Update () {

		// Keyboard input
		moveX = Input.GetAxis("Horizontal");
		moveY = Input.GetAxis("Vertical");
		if (Input.GetButtonDown("Jump")) jump = true;
		else jump = false;

		// Mouse input
		mouseX = Input.GetAxis("Mouse X");
		mouseY = Input.GetAxis("Mouse Y");

		// Atira flecha com botão do mouse
		if (Input.GetButtonDown("Fire1") && Time.timeScale == 1)
		{
			launcher.Launch();
		}

		// Pausa o jogo com Esc.
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			im.Pause();
		}
	}
}
