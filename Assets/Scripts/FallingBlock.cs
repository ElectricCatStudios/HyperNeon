using UnityEngine;
using System.Collections;

public class FallingBlock : MonoBehaviour {
	public float delay;
	private float timer;
	private bool touched = false;
	private Vector3 startPos;
	private Quaternion startDir;

	void Start(){
		timer = delay;
		startPos = transform.position;
		startDir = transform.rotation;
	}

	void OnCollisionEnter(Collision collision){
		if (collision.gameObject.tag == "Player"){
			touched = true;
		}
	}

	void Update(){
		if (touched) {
			timer -= Time.deltaTime;
			Debug.Log (timer);
		}

		if (timer <= 0) {
			Debug.Log ("calling aeouh");
			gameObject.rigidbody.isKinematic = false;
			rigidbody.WakeUp();
		}
	}

	public void Reset(){
		transform.position = startPos;
		transform.rotation = startDir;
		rigidbody.isKinematic = true;
		touched = false;
		timer = delay;
		Debug.Log ("resetting");
	}
}
