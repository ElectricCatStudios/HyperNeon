using UnityEngine;
using System.Collections;

public class CheckpointController : MonoBehaviour {
	public bool isActive = true;
	public int index;

	void OnTriggerEnter(Collider other) {
		if (isActive && other.gameObject.tag == "Player") {
			SetSpawn();
			isActive = false;
		}
	}

	public void SetSpawn(){
		LevelController.respawnPosition = transform.position;
	}
}
