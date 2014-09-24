using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour {
	public static Vector3 respawnPosition;
	public static GameObject player;

	void Start () {
		// level setup
		Time.timeScale = 1;
		player = GameObject.FindWithTag ("Player");
		respawnPosition = player.transform.position;
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.R)) {
			Respawn();
		}

		if (Input.GetKeyDown (KeyCode.Minus)){
			Time.timeScale -= 0.1f;
		}

		if (Input.GetKeyDown (KeyCode.Equals)){
			Time.timeScale += 0.1f;
		}

		if (Input.GetKeyDown (KeyCode.Backspace)) {
			Time.timeScale = 1;
		}
	}

	public static void Respawn()
	{
		player.transform.position = respawnPosition;
		player.rigidbody.velocity = Vector3.zero;
		player.rigidbody.angularVelocity = Vector3.zero;
		player.transform.rotation = Quaternion.Euler (new Vector3(270,90,0));
	}
}
