using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour {
	
	private static GameManager _instance;
	public static GameManager Instance{get{return _instance ?? (_instance = new GameManager());}}
	public Background background;
	public SpinningLine line;
	public TimeSpan RunningTime{get{return DateTime.UtcNow - started;}}
	public DateTime started; 
	public Projectile projectile;
	public FiringPatterns patterns;
	public HUDTab upperTab;
	public LeftHUDTab leftTab;
	public RightHUDTab rightTab;
	public LowerHUDTab lowerTab;

	public float projectileSpeed1 = 2.492f;
	public float projectileSpeed2 = 2.9f;
	public float projectileSpeed3 = 3.3f;
	public float projectileSpeed4 = 3.695f; 
	public float projectileSpeed5 = 4.1f; 
	public float projectileSpeed6 = 4.53f; 
	public float projectileSpeed7 = 4.88f; //
	public float projectileSpeed8 = 5.29f; 
	public float projectileSpeed9 = 5f; 
	public float projectileSpeed10 = 5.7f; 

	public float firstWaitTime1 = 1f; //60 BPM
	public float firstWaitTime2 = .8571428f; //70 BPM
	public float firstWaitTime3 = .75f; //80 BPM
	public float firstWaitTime4 = .6666667f; //90BPM
	public float firstWaitTime5 = .6f; //100BPM
	public float firstWaitTime6 = .5454545f; //110BPM
	public float firstWaitTime7 = .5f; //120BPM
	public float firstWaitTime8 = .4615385f; //130BPM
	public float firstWaitTime9 = .4285714f; //140BPM
	public float firstWaitTime10 = .4f; //150BPM

	public int lineSpinningSpeed1 = 181;
	public int lineSpinningSpeed2 = 214;
	public int lineSpinningSpeed3 = 241;
	public int lineSpinningSpeed4 = 276;
	public int lineSpinningSpeed5 = 302;
	public int lineSpinningSpeed6 = 336;
	public int lineSpinningSpeed7 = 359;
	public int lineSpinningSpeed8 = 390;
	public int lineSpinningSpeed9 = 2; //NOT USING
	public int lineSpinningSpeed10 = 445;

	public float speedChangeWaitTime = 4;
	public float secondWaitTime1 = 1.5f;
	public float secondWaitTime2 = 1.2f;
	public float secondWaitTime3 = .9f;
	public float secondWaitTime4 = .6f;

//	public int lineSpinningSpeed1 = 150;
//	public int lineSpinningSpeed2 = 178;
//	public int lineSpinningSpeed3 = 224;
//	public int lineSpinningSpeed4 = 296;
	
	public bool isGameOver;
	//public int speed;

	public int Points {get; private set;}  
	
	private GameManager(){
		//contructor to instantiate GameManager Singleton
	}

	void Start () {
		started = DateTime.UtcNow;    
//		upperTab.raiseUpperTab();  
//		leftTab.raiseLeftTab();  
//		rightTab.raiseRightTab(); 
//		lowerTab.openLowerTab();      
//		PlayerPrefs.SetInt("Mode", 1);            
//		determineMode();
	}

	void Update () {
//		if(Application.loadedLevel == 1){
//			HandleKeyboard();   
//			HandleUserTouches(); 
//		}

//		if(RunningTime.TotalSeconds > 15f){  
//			PlayerPrefs.SetInt("Mode", PlayerPrefs.GetInt("Mode") + 1);
//			determineMode();			 
//		} 
	}

	public void HandleKeyboard(){
		if (Input.GetKey(KeyCode.UpArrow)) {
			restartSession(); 
		}
	} 

	public void HandleUserTouches(){
		for (int i = 0; i < Input.touchCount; i++){  
			Touch touch = Input.GetTouch(i);
			if (touch.phase >= TouchPhase.Began){ //&& touch.tapCount == 1){
				Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);  
					restartSession();
			}
		}
	}
	 

	public void displayGameOverScreen(){
		//isGameOver = true;
		goToGameOverScene();
	}

	public void restartSession(){
		//isGameOver = false;
		Debug.Log("MORE SHTUFF");
//		upperTab.raiseUpperTab();  
//		leftTab.raiseLeftTab();
//		rightTab.lowerRightTab();
//		lowerTab.openLowerTab(); 
		returnToGame();
	}

	public void ResetPointsToZero(){
		Points = 0;     
	} 

	public void ResetPoints(int points){ 
		Points = points;
	}  
	
	public void AddPoints(int pointsToAdd){
		Points += pointsToAdd;
	}

	public void determineMode(){
//		if(PlayerPrefs.GetInt("Mode") == 0){
//			initiateWhiteMode();
//		}else if(PlayerPrefs.GetInt("Mode") == 1){
//			initiatePurpleMode();
//		}else if(PlayerPrefs.GetInt("Mode") == 2){
//			initiateBlueMode();
//		}else if(PlayerPrefs.GetInt("Mode") == 3){
//			initiateGreenMode();
//		}else if(PlayerPrefs.GetInt("Mode") == 4){
//			initiateYellowMode();
//		}else if(PlayerPrefs.GetInt("Mode") == 5){
//			initiateOrangeMode();
//		}else if(PlayerPrefs.GetInt("Mode") == 6){
//			initiateRedMode();
//		}else if(PlayerPrefs.GetInt("Mode") == 7){
//			initiateBlackMode(); 
//		}
		resetTimer();
	}

	public void resetTimer(){
		started = DateTime.UtcNow;
	}

	public void goToGameOverScene(){
		StartCoroutine(goToGameOverSceneCo());    
	}

	private IEnumerator goToGameOverSceneCo(){
		yield return new WaitForSeconds (.25f);
//		upperTab.lowerUpperTab();   
//		leftTab.lowerLeftTab();    
//		rightTab.lowerRightTab();      
//		lowerTab.closeLowerTab();  
		yield return new WaitForSeconds (.5f);
		Application.LoadLevel(0);
	}
 
	public void returnToGame(){
		StartCoroutine(returnToGameCo());    
	}
	
	private IEnumerator returnToGameCo(){   
		yield return new WaitForSeconds (.1f);   
		if(Application.loadedLevel == 1){  
			Debug.Log("SMELLOOO");
			Application.LoadLevel(0); 
		} 
	}

//	public void initiateWhiteMode(){
//		line.turnWhite();
//		background.initiateWhiteToPurpleAnimation();
//	}
//
//	public void initiatePurpleMode(){
//		line.turnPurple();
//		background.initiatePurpleToBlueAnimation();
//		projectile.Speed = 3f;
//		patterns.waitTime = .05f;         
//	}   
//
//	public void initiateBlueMode(){
//		line.turnBlue();
//		background.initiateBlueToGreenAnimation();
//		projectile.Speed = 3.1f;
//		patterns.waitTime = .9f;   
//	}      
//
//	public void initiateGreenMode(){
//		line.turnGreen();
//		background.initiateGreenToYellowAnimation();
//		projectile.Speed = 3.2f;
//		patterns.waitTime = .8f; 
//	}
//
//	public void initiateYellowMode(){
//		line.turnYellow();
//		background.initiateYellowToOrangeAnimation();
//		projectile.Speed = 3.3f;
//		patterns.waitTime = .7f; 
//	}
//
//	public void initiateOrangeMode(){
//		line.turnOrange();
//		background.initiateOrangeToRedAnimation();
//		projectile.Speed = 3.4f;
//		patterns.waitTime = .6f; 
//	}
//
//	public void initiateRedMode(){
//		line.turnRed();
//		background.initiateRedToBlackAnimation();
//		projectile.Speed = 3.5f;
//		patterns.waitTime = .5f; 
//	}      
//
//	public void initiateBlackMode(){
//		line.turnBlack();
//		background.initiateBlackAnimation();
//	}
}