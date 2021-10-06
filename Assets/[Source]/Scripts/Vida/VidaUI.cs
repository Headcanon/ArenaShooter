using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Atualiza a interface de vida
/// </summary>
public class VidaUI : MonoBehaviour {

	private Image[] images;
    private VidaPlayer vp;
	
	void Start () {
        images = GetComponentsInChildren<Image>();
        vp = FindObjectOfType<VidaPlayer>();
	}
	
	void Update () {
        for (int i = 0; i < images.Length; i++)
        {
            if (i < vp.vida)
            {
                images[i].enabled = true;
            }
			else
            {
                images[i].enabled = false;
            }
        }
    }
}
