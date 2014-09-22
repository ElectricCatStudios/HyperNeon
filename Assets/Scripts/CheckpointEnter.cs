using UnityEngine;
using System.Collections;

public class CheckpointEnter : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		LevelController.respawnPosition = transform.position;
		GameObject.Destroy (gameObject);
	}
}
