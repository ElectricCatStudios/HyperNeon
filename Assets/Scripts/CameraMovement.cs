using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
	public Transform cameraTransform;
	public Vector3 relativePosition;
	public float xSensitivity;
	public float ySensitivity;
	public bool lockCursor;


	// Use this for initialization
	void Start () {
		Screen.lockCursor = lockCursor;
		cameraTransform.position = transform.position + relativePosition;
	}
	
	// Update is called once per frame
	void Update () {
		relativePosition = Quaternion.Euler (0, Input.GetAxis ("Mouse X") * xSensitivity * Time.deltaTime, 0) * relativePosition;

		cameraTransform.RotateAround (transform.position, Vector3.up, Input.GetAxis("Mouse X")*xSensitivity*Time.deltaTime);
		cameraTransform.position = transform.position + relativePosition;
	}
}
