using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {
	public int buttonWidth = 96;
	public int buttonHeight = 64;
	private Rect[] levelButtons;
	private string[] scenes;

	void Start(){
		scenes = gameObject.GetComponent<GetSceneNames>().scenes;
		int buttonWidth = 128;
		int buttonHeight = 48;
		int buttonXSpace = 32;
		int buttonYSpace = 16;
		int buttonsPerColumn = 5;
		levelButtons = new Rect[scenes.Length];

		CreateRects (buttonWidth, buttonHeight, buttonXSpace, buttonYSpace, (levelButtons.Length + buttonsPerColumn - 1) / buttonsPerColumn, levelButtons);
	}

	void OnGUI(){
		for (int i = 0; i < levelButtons.Length; i++) {
			if (GUI.Button (levelButtons[i],(i + 1) + ": " + scenes[i])){
				Application.LoadLevel (i);
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
}