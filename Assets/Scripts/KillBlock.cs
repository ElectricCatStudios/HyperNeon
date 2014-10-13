using UnityEngine;
using System.Collections;

public class KillBlock : MonoBehaviour {

	void OnCollisionEnter(Collision collision){
		if (collision.gameObject.tag == "Player") {
			LevelController.Respawn ();
		}
	}
}
