using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ToggleRotate : MonoBehaviour {

	public GameObject go;

	void Start () {
		GetComponent<Toggle> ().onValueChanged.AddListener(HandleToggle);
	}

	void HandleToggle (bool isOn) {
		go.GetComponent<HandRotate> ().enabled = isOn;
		go.GetComponent<GyroRotate> ().enabled = !isOn;
	}
}
