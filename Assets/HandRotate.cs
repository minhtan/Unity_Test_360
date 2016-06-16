using UnityEngine;
using System.Collections;
using Lean;

public class HandRotate : MonoBehaviour {

	float sensitivity = 0.5f;

	void Start () {
//		LeanTouch.OnFingerDown += OnFingerDown;
		LeanTouch.OnFingerDrag += HandleDrag;
	}

	void HandleDrag (LeanFinger fg) {
		var swipe = fg.SwipeDelta;

		//map the x rotationRate for continuos rotation when the device is mveing
		float xFiltered = FilterGyroValues(-swipe.y, "x");
		RotateUpDown(xFiltered);

		//map the y rotationRate for continuos rotation when the device is moving
		float yFiltered = FilterGyroValues(swipe.x, "y");
		RotateRightLeft(yFiltered);

		Debug.Log ("swiped");
	}

	float FilterGyroValues(float axis, string axisName) {
		if (axis < -0.1 || axis > 0.1) {
			return axis;
		} else {
			return 0;
		}
	}

	//rotate the camera up and down(x rotation)
	void RotateUpDown(float axis){
		transform.RotateAround(transform.position , transform.right, -axis * Time.deltaTime * sensitivity);
	}

	//rotate the camera rigt and left (y rotation)
	void RotateRightLeft(float axis){
		transform.RotateAround(transform.position, Vector3.up, -axis * Time.deltaTime * sensitivity);
	}
}


