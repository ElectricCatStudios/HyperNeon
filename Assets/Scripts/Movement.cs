using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	public float forceCoeff;
	public float jumpCoeff;
	public float torqueCoeff;
	public float jumpMargin;	// how far can the ball be from the ground for it to jump
	public float jumpDetRad;	// the ratio of the jump detection sphere and  sphere collider radii
	public float maxAngularVel;
	public float jumpDelay;
	public bool useConeFriction;
	public RigidbodyInterpolation interpolation;
	public int iterationCount;

	private Vector3 jumpDetectionOffset;
	private Transform cameraTransform;
	private bool jumpPressed = false;
	private float lastJump = 0;

	// Use this for initialization
	void Start () {
		cameraTransform = Camera.main.transform;
		jumpDetectionOffset = new Vector3 (0, -jumpMargin, 0);
		rigidbody.maxAngularVelocity = maxAngularVel;
		rigidbody.useConeFriction = useConeFriction;
		rigidbody.interpolation = interpolation;
		rigidbody.solverIterationCount = iterationCount;
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
		if (jumpPressed && Physics.CheckSphere (transform.position + jumpDetectionOffset, GetComponent<SphereCollider>().radius * jumpDetRad, LayerMask.GetMask("MapGeometry")))
		{
			rigidbody.AddForce (Physics.gravity.normalized * -jumpCoeff, ForceMode.Impulse);
		}

		// force/torque application
		rigidbody.AddForce (tForce, ForceMode.Force);
		rigidbody.AddTorque (tTorque, ForceMode.Force);
	}

	// Update is called once per frame
	void Update () {
		//jumpPressed = (((Input.GetKeyDown (KeyCode.Mouse0) && !LevelController.menuOpen) || Input.GetKeyDown (KeyCode.Space)) || jumpPressed);
		if ((Input.GetKeyDown (KeyCode.Mouse0) && !LevelController.menuOpen) || Input.GetKeyDown (KeyCode.Space)) {
			if (Time.time - lastJump > jumpDelay) {
				jumpPressed = true;
				lastJump = Time.time;
			}
		} else if ((Input.GetKeyUp (KeyCode.Mouse0) && !LevelController.menuOpen) || Input.GetKeyUp (KeyCode.Space)) {
			jumpPressed = false;
		}
	}
}
