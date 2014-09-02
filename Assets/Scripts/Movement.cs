using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	public float forceCoeff;
	public float jumpCoeff;
	public float torqueCoeff;
	public float jumpMargin;	// how far can the ball be from the ground for it to jump

	private Transform cameraTransform;

	// Use this for initialization
	void Start () {
		cameraTransform = gameObject.GetComponent <CameraMovement>().cameraTransform;
	}

	void FixedUpdate(){
		// translational forces
		Vector3 fForce = Input.GetAxisRaw ("Vertical") * Vector3.Scale (cameraTransform.forward, new Vector3 (1, 0, 1));
		Vector3 hForce = Input.GetAxisRaw ("Horizontal") * Vector3.Scale (cameraTransform.right, new Vector3 (1, 0, 1));
		Vector3 tForce = (fForce + hForce).normalized * forceCoeff;

		// torques
		Vector3 fTorque = Input.GetAxisRaw ("Vertical") * (Vector3.Scale (cameraTransform.right, new Vector3 (1, 0, 1))).normalized * torqueCoeff;
		Vector3 hTorque = Input.GetAxisRaw("Horizontal")* (Vector3.Scale (cameraTransform.forward, new Vector3(1, 0, 1))).normalized * -torqueCoeff;
		Vector3 tTorque = (fTorque + hTorque).normalized * torqueCoeff;

		// jumping
		if ((Input.GetKeyDown (KeyCode.Mouse0) || Input.GetKeyDown (KeyCode.Space)) && (Physics.Raycast (transform.position, Vector3.down, GetComponent<SphereCollider>().radius + jumpMargin)))
		{
			rigidbody.AddForce (Physics.gravity.normalized * -jumpCoeff, ForceMode.Impulse);
		}

		// force/torque application
		rigidbody.AddForce (tForce, ForceMode.Force);
		rigidbody.AddTorque (tTorque, ForceMode.Force);
	}

	// Update is called once per frame
	void Update () {
		
	}
}
