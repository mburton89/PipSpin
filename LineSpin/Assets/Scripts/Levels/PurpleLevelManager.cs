using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PurpleLevelManager : MonoBehaviour {
	
//	//private static GameManager _instance;
//	//public static GameManager Instance{get{return _instance ?? (_instance = new GameManager());}}
//	public Background background;
//	public SpinningLine line;
//	public TimeSpan RunningTime{get{return DateTime.UtcNow - started;}}
//	public DateTime started;
//	
//	public int Points {get; private set;}
//	
//	private PurpleLevelManager(){
//		//contructor to instantiate GameManager Singleton
//	}
//	
//	void Start () {
//		started = DateTime.UtcNow; 
//		initiatePurpleMode();
//	}
//	
//	void Update () {
//		if(RunningTime.TotalSeconds > 30f){
//					 
//		} 
//	}
//
//	public void determineMode(){
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
//		resetTimer();
//	}
//	
//	public void resetTimer(){
//		started = DateTime.UtcNow;
//	}
//	
//	public void initiateWhiteMode(){
//		line.turnWhite();
//		background.initiateWhiteToPurpleAnimation();
//	}
//	
//	public void initiatePurpleMode(){
//		line.turnPurple();
//		background.initiatePurpleToBlueAnimation();
//	}
//	
//	public void initiateBlueMode(){
//		line.turnBlue();
//		background.initiateBlueToGreenAnimation();
//	}
//	
//	public void initiateGreenMode(){
//		line.turnGreen();
//		background.initiateGreenToYellowAnimation();
//	}
//	
//	public void initiateYellowMode(){
//		line.turnYellow();
//		background.initiateYellowToOrangeAnimation();
//	}
//	
//	public void initiateOrangeMode(){
//		line.turnOrange();
//		background.initiateOrangeToRedAnimation();
//	}
//	
//	public void initiateRedMode(){
//		line.turnRed();
//		background.initiateRedToBlackAnimation();
//	}
//	
//	public void initiateBlackMode(){
//		line.turnBlack();
//		background.initiateBlackAnimation();
//	}
}