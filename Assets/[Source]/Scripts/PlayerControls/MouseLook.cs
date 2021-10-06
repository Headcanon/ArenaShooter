using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controle da visão de player
/// </summary>
public class MouseLook : MonoBehaviour {

    private PInput pInput;
    private PlayerMoveData moveData;
    private float xRotation = 0f;

    void Start()
    {
        pInput = FindObjectOfType<PInput>();
        moveData = transform.parent.GetComponent<PlayerMoveData>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        float mouseX = pInput.mouseX * moveData.mouseSensitivity * Time.deltaTime;
        float mouseY = pInput.mouseY * moveData.mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        moveData.cc.transform.Rotate(Vector3.up * mouseX);
    }
}
