using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Checa se player está no chão
/// </summary>
public class GroundChecker : MonoBehaviour {

	private PlayerMoveData moveData;

	// Use this for initialization
	void Start () {
		moveData = transform.parent.GetComponent<PlayerMoveData>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		moveData.isGrounded = Physics.CheckSphere(transform.position, moveData.groundDistance, moveData.groundMask);
	}
}
