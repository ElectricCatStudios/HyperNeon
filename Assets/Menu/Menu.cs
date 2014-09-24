using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {
	public int buttonWidth = 96;
	public int buttonHeight = 64;

	private Rect buttonRect;

	void Start(){
		buttonRect = new Rect (
			Screen.width / 2 - buttonWidth / 2,
			Screen.height / 2 - buttonHeight / 2,
			buttonWidth,
			buttonHeight);
	}

	void OnGUI(){
		if (GUI.Button (buttonRect, "START!")) {
			Application.LoadLevel ("TestScene");
		}
	}
}
