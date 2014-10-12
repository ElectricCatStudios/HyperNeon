using UnityEngine;
using System.Collections;

public class KillBlock : MonoBehaviour {

	void OnCollisionEnter(){
		LevelController.Respawn ();
	}
}
