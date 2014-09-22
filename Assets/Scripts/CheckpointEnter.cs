using UnityEngine;
using System.Collections;

public class CheckpointEnter : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player") {
				LevelController.respawnPosition = transform.position;
				GameObject.Destroy (gameObject);
		}
	}
}
