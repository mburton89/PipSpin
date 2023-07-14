using UnityEngine;
using System.Collections;

public class v3Menu : MonoBehaviour {

	public GameObject NormalButton;
	public GameObject InsaneButton;

	//public GUISkin Skin;
	public string levelTitle;
	public bool isDisplayingInsaneMode;
	
	void Start () {
		if (PlayerPrefs.GetInt ("hasReachedInsaneSpeeds") == 1) {
			displayInsaneModeScreen();	
			isDisplayingInsaneMode = true;
		} else {
			displayNormalModeScreen();	
			isDisplayingInsaneMode = false;
		}

	}
	
	void Update () {
		HandleKeyboard();
		HandleUserTouches();
	}
	
	public void HandleKeyboard(){
		if (Input.GetKeyDown(KeyCode.LeftArrow)) {
			toggleDifficulty();
		} else if (Input.GetKeyDown (KeyCode.S)) {
			startGame();
		} else if (Input.GetKeyDown (KeyCode.Alpha1)) {
			openSettings();
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
					toggleDifficulty();
				}
			}
		}
	}


	public void toggleDifficulty(){
		if(isDisplayingInsaneMode == true){
			displayNormalModeScreen();
		}else{
			displayInsaneModeScreen();
		}
	}

	public void displayInsaneModeScreen(){
		//Show InsaneSprite
		//Flip Colors
		NormalButton.GetComponent<SpriteRenderer> ().enabled = false;
		InsaneButton.GetComponent<SpriteRenderer> ().enabled = true;
		isDisplayingInsaneMode = true;
	}

	public void displayNormalModeScreen(){
		//Show InsaneSprite
		//Flip Colors
		InsaneButton.GetComponent<SpriteRenderer> ().enabled = false;
		NormalButton.GetComponent<SpriteRenderer> ().enabled = true;
		isDisplayingInsaneMode = false;
	}

	public void startGame(){
		if(isDisplayingInsaneMode == true){
			Application.LoadLevel(1);
		}else{
			Application.LoadLevel(2);
		}
		hideMenu();
	}

	public void displayLeaderboards(){

	}

	public void displayAchievements(){
		
	}

	public void openSettings(){
		Application.LoadLevel (4);
	}

	public void initiateRemoveAdsProcess(){
		
	}

	public void hideMenu(){
		
	}

//	public void OnGUI(){
//		GUI.skin = Skin;
//		GUILayout.BeginArea(new Rect(0 ,0, Screen.width, Screen.height)); //also added padding for GameSkin on Inspector
//		{
//			GUILayout.BeginVertical(Skin.GetStyle("EnemyKillText"));
//			{
//				//if(Application.loadedLevel == 0){
//				GUILayout.Label(string.Format("{0}", levelTitle), Skin.GetStyle("EnemyKillText")); 
//				//}
//			}
//			GUILayout.EndVertical();
//		}
//		GUILayout.EndArea();
//	}
}
