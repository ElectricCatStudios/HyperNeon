using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour {
	public static bool menuOpen = false;

	public int buttonWidth = 96;
	public int buttonHeight = 64;

	private Rect menuButRect;
	private Rect resumeButRect;

	// Use this for initialization
	void Start () {
		// level setup
		Time.timeScale = 1;
		menuOpen = false;

		menuButRect = new Rect (
			Screen.width / 2 - buttonWidth / 2,
			Screen.height / 2 - buttonHeight / 2,
			buttonWidth,
			buttonHeight);

		resumeButRect = new Rect (
			Screen.width / 2 - buttonWidth / 2,
			Screen.height / 2 - buttonHeight / 2 + buttonHeight + 32,
			buttonWidth,
			buttonHeight);
	}

	void OnGUI(){
		if (menuOpen) {
			if (GUI.Button (menuButRect, "Back To Menu")) {
				Application.LoadLevel ("MenuScene");
			}

			if (GUI.Button (resumeButRect, "Resume")) {
				CloseMenu ();
			}
		}
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			ToggleMenu();
		}

		if (Input.GetKeyDown (KeyCode.R)) {
			Application.LoadLevel(Application.loadedLevel);
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

	void OpenMenu(){
		menuOpen = true;
		Time.timeScale = 0;
	}

	void CloseMenu(){
		menuOpen = false;
		Time.timeScale = 1;
	}

	void ToggleMenu(){
		if (menuOpen) {
			CloseMenu ();
		} else {
			OpenMenu ();
		}
	}
}
