using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ToggleObject : MonoBehaviour {

	public GameObject go1;
	public GameObject go2;

	void Start () {
		GetComponent<Toggle> ().onValueChanged.AddListener(HandleToggle);
	}

	void HandleToggle (bool isOn) {
		go1.SetActive (isOn);
		go2.SetActive (!isOn);
	}
}
