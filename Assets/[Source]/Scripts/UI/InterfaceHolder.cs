using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Ativa ou desativa um objeto child. Facilita o controle das UIs
/// </summary>
public class InterfaceHolder : MonoBehaviour {
	
	public void ShowInterface()
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }

    public void HideInterface()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }
}
