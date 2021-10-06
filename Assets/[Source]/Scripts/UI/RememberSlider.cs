using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Pega de volta o valor salvo do slider
/// </summary>
public class RememberSlider : MonoBehaviour {

    [SerializeField] private string pref;

	private Slider slider;

    void Start () {
		slider = GetComponent<Slider>();
		slider.value = PlayerPrefs.GetFloat(pref, 1f);
	}
}
