using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {
	public static bool menuOpen = false;
	private string mode = "none";
	private GameObject[] checkpoints;
	
	private Rect[] pauseButtons = new Rect[3];
	private Rect[] checkpointButtons;
	
	public void Start(){
		// init pause buttons
		int buttonWidth = 128;
		int buttonHeight = 48;
		int buttonXSpace = 32;
		int buttonYSpace = 16;
		int buttonsPerColumn = 5;
		CreateRects (buttonWidth, buttonHeight, buttonXSpace, buttonYSpace, 1, pauseButtons);
		
		// init checkpoint buttons
		checkpoints = GameObject.FindGameObjectsWithTag("Checkpoint");
		checkpointButtons = new Rect[checkpoints.Length];
		Debug.Log ("checkpoints: " + checkpointButtons.Length);
		CreateRects (buttonWidth, buttonHeight, buttonXSpace, buttonYSpace, (checkpoints.Length+buttonsPerColumn-1)/buttonsPerColumn, checkpointButtons);
	}
	
	public void PrintMode(){
		Debug.Log (mode);
	}
	
	public void Update(){
		if (Input.GetKeyDown (KeyCode.Escape)) {
			ToggleMenu("pause");
		}
		
		if (Input.GetKeyDown (KeyCode.C)) {
			ToggleMenu ("checkpoint");
		}
	}
	
	void OnGUI(){
		if (mode != "none") {
			switch(mode){
			case "pause":
				ShowPause();
				break;
			case "checkpoint":
				ShowCheckpoint();
				break;
			}
		}
	}
	
	private void ShowPause(){
		if (GUI.Button (pauseButtons[0], "Exit to Menu")) {
			Application.LoadLevel ("MenuScene");
		}
		
		if (GUI.Button (pauseButtons[1], "Resume")) {
			ToggleMenu();
		}
		
		if (GUI.Button (pauseButtons [2], "Checkpoints")) {
			mode = "checkpoint";
		}
	}
	
	private void ShowCheckpoint(){
		for (int i = 0; i < checkpoints.Length; i++) {
			if (GUI.Button (checkpointButtons[i], "Checkpoint " + (i + 1))){
				foreach (GameObject checkpoint in checkpoints){
					CheckpointController controller = checkpoint.GetComponent<CheckpointController>();
					controller.isActive = true;
					if (controller.index == (i + 1)) {
						controller.SetSpawn();
					}
					LevelController.Respawn();
				}
			}
		}
	}
	
	private void CreateRects(int width, int height, int xSpace, int ySpace, int columns, Rect[] buttonArray){
		int butNum = buttonArray.Length;
		int columnLen = butNum / columns + butNum % columns;
		int startHeight = (Screen.height - (columnLen) * height - (columnLen - 1) * ySpace) / 2;
		int startWidth = (Screen.width - (columns) * width - (columns - 1) * xSpace) / 2;
		int dHeight = ySpace + height;
		int dWidth = xSpace + width;

		for (int i = 0; i < columns; i++){
			for(int j = 0; j < columnLen; j++){
				if (butNum > i + j*columns){
					buttonArray[i + j*columns] = new Rect(
						startWidth + dWidth * i,
						startHeight + dHeight * j,
						width,
						height);
				}
			}
		}
	}
	
	private void ToggleMenu(string menu){
		if (mode == "none") {
			mode = menu;
			Time.timeScale = 0;
			menuOpen = true;
		} else {
			mode = "none";
			Time.timeScale = 1;
			menuOpen = false;
		}
	}
	
	private void ToggleMenu(){
		if (mode == "none") {
			mode = "pause";
			Time.timeScale = 0;
			menuOpen = true;
		} else {
			mode = "none";
			Time.timeScale = 1;
			menuOpen = false;
		}
	}
}
