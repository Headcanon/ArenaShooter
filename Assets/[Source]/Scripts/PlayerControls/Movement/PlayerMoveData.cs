using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Dados sobre o movimento da personagem jogável
/// </summary>
[RequireComponent(typeof(CharacterController))]
public class PlayerMoveData : MonoBehaviour {

    [Header("Controller")]
    public float mouseSensitivity = 100f;
    public float moveSpeed = 25f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    [HideInInspector] public CharacterController cc;
    [HideInInspector] public Vector3 velocity;


    [Header("GroundCheck")]
    public LayerMask groundMask;
    public float groundDistance = .4f;

     public bool isGrounded = false;

    private void Start()
    {
        cc = GetComponent<CharacterController>();
    }
}
