using UnityEngine;
using System.Collections;

public class v2Menu : MonoBehaviour {
	
	public GUISkin Skin;
	//public int levelNumber;
	public string levelTitle;
	
	void Start () {
		levelTitle = "REACT";
	}
	
	void Update () {
		HandleKeyboard();
		HandleUserTouches();
	}
	
	public void HandleKeyboard(){
		if (Input.GetKeyDown(KeyCode.LeftArrow)) {
			decreaseLevelToChoose();
		} else if (Input.GetKeyDown (KeyCode.RightArrow)) {
			increaseLevelToChoose();
		} else if (Input.GetKeyDown (KeyCode.S)) {
			startGame();
		}
	}

	public void HandleUserTouches(){
		for (int i = 0; i < Input.touchCount; i++){  
			Touch touch = Input.GetTouch(i);
			if (touch.phase == TouchPhase.Began){
				Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);  
				if(touchPosition.x < 1 && touchPosition.x > -1){
					startGame(); 
				}else if(touchPosition.x < -1){
					decreaseLevelToChoose();
				}else if(touchPosition.x > 1){
					increaseLevelToChoose();  
				}
			}
		}
	}


	public void increaseLevelToChoose(){
		if(levelTitle == "REACT"){
			levelTitle = "FOCUS";
		}else if(levelTitle == "FOCUS"){
			levelTitle = "SPIN";
		}
	}
	
	public void decreaseLevelToChoose(){
		if(levelTitle == "SPIN"){
			levelTitle = "FOCUS";
		}else if(levelTitle == "FOCUS"){
			levelTitle = "REACT";
		}
	}
	
	public void startGame(){
		if(levelTitle == "REACT"){
			Application.LoadLevel(1);
		}else if(levelTitle == "FOCUS"){
			Application.LoadLevel(2);
		}else if(levelTitle == "SPIN"){
			Application.LoadLevel(3);
		}
		hideMenu();
	}
	
	public void hideMenu(){
		
	}
	
	public void OnGUI(){
		GUI.skin = Skin;
		GUILayout.BeginArea(new Rect(0 ,0, Screen.width, Screen.height)); //also added padding for GameSkin on Inspector
		{
			GUILayout.BeginVertical(Skin.GetStyle("EnemyKillText"));
			{
				//if(Application.loadedLevel == 0){
				GUILayout.Label(string.Format("{0}", levelTitle), Skin.GetStyle("EnemyKillText")); 
				//}
			}
			GUILayout.EndVertical();
		}
		GUILayout.EndArea();
	}
}
