using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Movimento da personagem jogável
/// </summary>
[RequireComponent(typeof(PlayerMoveData))]
public class FPSMovement : MonoBehaviour {

    private PlayerMoveData moveData;
    private PInput pInput;

    void Start()
    {
        moveData = GetComponent<PlayerMoveData>();
        pInput = FindObjectOfType<PInput>();
    }

    void Update()
    {
        if (moveData.isGrounded && moveData.velocity.y < 0)
        {
            moveData.velocity.y = -1.5f;
        }

        float x = pInput.moveX;
        float z = pInput.moveY;

        Vector3 move;
        move = transform.right * x + transform.forward * z;

        moveData.cc.Move(move * moveData.moveSpeed * Time.deltaTime);

        if (pInput.jump && moveData.isGrounded)
        {
            moveData.velocity.y = Mathf.Sqrt(moveData.jumpHeight * -2f * moveData.gravity);
        }

        moveData.velocity.y += moveData.gravity * Time.deltaTime;

        moveData.cc.Move(moveData.velocity * Time.deltaTime);
    }
}
