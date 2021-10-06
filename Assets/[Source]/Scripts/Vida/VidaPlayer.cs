using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Vida de player. Quando morre da Game Over
/// </summary>
public class VidaPlayer : Vida {

	protected override void Die()
    {
        FindObjectOfType<InterfaceManager>().Die();
    }
}
