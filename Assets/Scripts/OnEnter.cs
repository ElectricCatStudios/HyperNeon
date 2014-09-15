using UnityEngine;
using System.Collections;

public class OnEnter : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		LevelController.respawnPosition = transform.position;
		Debug.Log ("lala");
		GameObject.Destroy (gameObject);
	}
}
