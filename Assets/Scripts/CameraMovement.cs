using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
	
	public Transform target;
	public float targetDistance = 5.0f;
	
	public float yMinLimit = -20f;
	public float yMaxLimit = 80f;
	
	public float distanceMin = .5f;
	public float distanceMax = 15f;

	public float cameraMargin = 0.2f;
	public float minAlpha = 0.1f;
	public float alphaBeginThreshold = 1f;

	private Vector3 targetPos;
	
	float x = 0.0f;
	float y = 0.0f;
	
	// Use this for initialization
	void Start () {
		Vector3 angles = transform.eulerAngles;
		x = angles.y;
		y = angles.x;
		
		// Make the rigid body not change rotation
		if (rigidbody)
			rigidbody.freezeRotation = true;

		targetPos = target.transform.position;
		Screen.lockCursor = true;
	}
	
	void LateUpdate () {
		float distance = targetDistance;
		Debug.DrawRay (transform.position+ -transform.forward*0.2f, transform.forward*((targetPos - transform.position).magnitude));
		GameObject targetGameObject = target.gameObject;
		targetPos = target.transform.position;

		if (target) {
			if (!LevelController.menuOpen){
				x += Input.GetAxis ("Mouse X") * 0.02f;
				y -= Input.GetAxis ("Mouse Y") * 0.02f;
			}

			y = ClampAngle (y, yMinLimit, yMaxLimit);
			
			Quaternion rotation = Quaternion.Euler (y, x, 0);
			
			targetDistance = Mathf.Clamp (distance - Input.GetAxis ("Mouse ScrollWheel"), distanceMin, distanceMax);

			Vector3 negDistance = new Vector3 (0.0f, 0.0f, -distance);
			Vector3 position = rotation * negDistance + targetPos;
			
			transform.rotation = rotation;
			transform.position = position;

			// to do: add more raycasts
			while (Physics.Raycast (target.position, -transform.forward,(target.position - transform.position).magnitude + cameraMargin, 1 << 8)) {
				distance -= 0.01f;
				negDistance = new Vector3 (0.0f, 0.0f, -distance);
				position = rotation * negDistance + targetPos;
				
				transform.rotation = rotation;
				transform.position = position;
			}

			Color targetOldColor = targetGameObject.renderer.material.color;
			Color targetColor = new Color (targetOldColor.r, targetOldColor.g, targetOldColor.b, Mathf.Lerp (minAlpha, 1f, distance / alphaBeginThreshold)); 
			targetGameObject.renderer.material.color = targetColor;
		}
	}
	
	public static float ClampAngle(float angle, float min, float max)
	{
		if (angle < -360F)
			angle += 360F;
		if (angle > 360F)
			angle -= 360F;
		return Mathf.Clamp(angle, min, max);
	}
	
	
}