﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class v3PairsDispenser : MonoBehaviour {

	//DIRECTIONS
	public Vector2 downRight = new Vector2 (1, -1);
	public Vector2 downLeft = new Vector2 (-1, -1);

	//PROJECTILE SPAWN LOCATIONS
	private Vector3 Left1ProjectileSpawnLocation = new Vector3 (-10.5f, 5f, 0);       
	private Vector3 Left2ProjectileSpawnLocation = new Vector3 (-5.5f, 5f, 0);      
	private Vector3 Right1ProjectileSpawnLocation = new Vector3 (5.5f, 5f, 0);  
	private Vector3 Right2ProjectileSpawnLocation = new Vector3 (10.5f, 5, 0);

	//OBJECTS
	public Projectile projectile;
	public Projectile projectile2;
	public virtual Vector2 direction { get; protected set;}
	public SpinningLine line;
	public Background background;
	public DateTime started; 
	public TimeSpan RunningTime{get{return DateTime.UtcNow - started;}}
	private static System.Random random = new System.Random();

	//VARIABLES
	public float waitTime;  
	public float waitTime2;  
	public int activeProjectiles;
	public int spinningSpeed;

	public bool canFire;
	public bool hasWaitedForFirstSpeedChange;
	public bool hasWaitedForSecondSpeedChange;
	public bool hasWaitedForThirdSpeedChange;
	public bool hasWaitedForFourthSpeedChange;
	public bool hasWaitedForFifthSpeedChange;
	public bool hasWaitedForSixthSpeedChange;
	public bool hasWaitedForSeventhSpeedChange;
	public bool hasWaitedForEighthSpeedChange;
	public bool hasWaitedForNinthSpeedChange;

	public bool hasMostRecentlyFired1And2;
	public bool hasMostRecentlyFired1And3;  
	public bool hasMostRecentlyFired2And4;
	public bool hasMostRecentlyFired3And4;

	void Start () {
		hasMostRecentlyFired1And2 = true;
		canFire = true;
		started = DateTime.UtcNow; 
		determineSpeeds();
		//initiateSpinScenario();
		fireRandomSequence(); 
	}
	
	// Update is called once per frame
	void Update () {
		determineSpeeds();
	}

	public void fire1And2(){
		if(canFire){

			//PROJECTILE 1
			var liveProjectile = (Projectile)Instantiate (projectile, Left1ProjectileSpawnLocation, transform.rotation); 
			liveProjectile.Initialize (gameObject, downRight, new Vector2(1, -1)); 
			liveProjectile.GetComponent<SpriteRenderer>().color = line.GetComponent<SpriteRenderer>().color;
			
			//PROJECTILE 2
			var liveProjectile2 = (Projectile)Instantiate (projectile, Left2ProjectileSpawnLocation, transform.rotation); 
			liveProjectile2.Initialize (gameObject, downRight, new Vector2(1, -1));
			liveProjectile2.GetComponent<SpriteRenderer>().color = line.GetComponent<SpriteRenderer>().color;
			
			hasMostRecentlyFired1And2 = true;
			hasMostRecentlyFired1And3 = false;
			hasMostRecentlyFired2And4 = false;
			hasMostRecentlyFired3And4 = false;
		}
	}

	public void fire1And3(){
		if(canFire){
			
			//PROJECTILE 1
			var liveProjectile = (Projectile)Instantiate (projectile, Left1ProjectileSpawnLocation, transform.rotation); 
			liveProjectile.Initialize (gameObject, downRight, new Vector2(1, -1));
			liveProjectile.GetComponent<SpriteRenderer>().color = line.GetComponent<SpriteRenderer>().color;
			
			//PROJECTILE 3
			var liveProjectile3 = (Projectile)Instantiate (projectile, Right1ProjectileSpawnLocation, transform.rotation); 
			liveProjectile3.Initialize (gameObject, downLeft, new Vector2(-1, -1));
			liveProjectile3.GetComponent<SpriteRenderer>().color = line.GetComponent<SpriteRenderer>().color;
			
			hasMostRecentlyFired1And2 = false;
			hasMostRecentlyFired1And3 = true;
			hasMostRecentlyFired2And4 = false;
			hasMostRecentlyFired3And4 = false;
		}
	}

	public void fire2And4(){
		if(canFire){
			//PROJECTILE 2
			var liveProjectile2 = (Projectile)Instantiate (projectile, Left2ProjectileSpawnLocation, transform.rotation); 
			liveProjectile2.Initialize (gameObject, downRight, new Vector2(1, -1)); 
			liveProjectile2.GetComponent<SpriteRenderer>().color = line.GetComponent<SpriteRenderer>().color;
			
			//PROJECTILE 4
			var liveProjectile4 = (Projectile)Instantiate (projectile, Right2ProjectileSpawnLocation, transform.rotation); 
			liveProjectile4.Initialize (gameObject, downLeft, new Vector2(-1, -1));
			liveProjectile4.GetComponent<SpriteRenderer>().color = line.GetComponent<SpriteRenderer>().color;
			
			hasMostRecentlyFired1And2 = false;
			hasMostRecentlyFired1And3 = false;
			hasMostRecentlyFired2And4 = true;
			hasMostRecentlyFired3And4 = false;
		}
	}

	public void fire3And4(){
		if(canFire){
			
			//PROJECTILE 3
			var liveProjectile3 = (Projectile)Instantiate (projectile, Right1ProjectileSpawnLocation, transform.rotation); 
			liveProjectile3.Initialize (gameObject, downLeft, new Vector2(-1, -1)); 
			liveProjectile3.GetComponent<SpriteRenderer>().color = line.GetComponent<SpriteRenderer>().color;
			
			//PROJECTILE 4
			var liveProjectile4 = (Projectile)Instantiate (projectile, Right2ProjectileSpawnLocation, transform.rotation); 
			liveProjectile4.Initialize (gameObject, downLeft, new Vector2(-1, -1));
			liveProjectile4.GetComponent<SpriteRenderer>().color = line.GetComponent<SpriteRenderer>().color;
			
			hasMostRecentlyFired1And2 = false;
			hasMostRecentlyFired1And3 = false;
			hasMostRecentlyFired2And4 = false;
			hasMostRecentlyFired3And4 = true;
		}
	}

	public void fireRandomSequence(){
		if(hasMostRecentlyFired1And2){
			fireScenarioCompatablePost1And2();
		}else if(hasMostRecentlyFired1And3){
			fireScenarioCompatablePost1And3();
		}else if(hasMostRecentlyFired2And4){
			fireScenarioCompatablePost2And4();
		}else if(hasMostRecentlyFired3And4){
			fireScenarioCompatablePost3And4();
		}
	}

	public void fireScenarioCompatablePost1And2(){
		float sequenceNumber = random.Next (1, 8);
		if(sequenceNumber == 1){ 
			fire1And3();
			wait ();
		}else if(sequenceNumber == 2){
			fire2And4();
			wait ();
		}else if(sequenceNumber == 3){
			fire3And4();
			wait ();
		}else if(sequenceNumber == 4 || sequenceNumber == 7){
			initiateSpinScenario();
		}else if(sequenceNumber == 5){
			initiateBackAndForthIntersectingScenario();
		}else if(sequenceNumber == 6){
			initiateBackAndForthPairsScenario();
		}
		//wait ();
	}

	public void fireScenarioCompatablePost1And3(){
		float sequenceNumber = random.Next (1, 8);
		if(sequenceNumber == 1){   
			fire1And2();
			wait ();
		}else if(sequenceNumber == 2){
			fire2And4();
			wait ();
		}else if(sequenceNumber == 3){
			fire3And4();
			wait ();
		}else if(sequenceNumber == 4 || sequenceNumber == 7){
			initiateSpinScenario();
		}else if(sequenceNumber == 5){
			initiateBackAndForthIntersectingScenario();
		}else if(sequenceNumber == 6){
			initiateBackAndForthPairsScenario();
		}
	}

	public void fireScenarioCompatablePost2And4(){
		float sequenceNumber = random.Next (1, 8);
		if(sequenceNumber == 1){   
			fire1And2();
			wait ();
		}else if(sequenceNumber == 2){
			fire1And3();
			wait ();
		}else if(sequenceNumber == 3){
			fire3And4();
			wait ();
		}else if(sequenceNumber == 4 || sequenceNumber == 7){
			initiateSpinScenario();
		}else if(sequenceNumber == 5){
			Debug.Log("THAT IS HAPPENING LALALALL");
			initiateBackAndForthIntersectingScenario();
		}else if(sequenceNumber == 6){
			initiateBackAndForthPairsScenario();
		}
	}

	public void fireScenarioCompatablePost3And4(){
		float sequenceNumber = random.Next (1, 8);
		if(sequenceNumber == 1){   
			fire1And2();
			wait ();
		}else if(sequenceNumber == 2){
			fire1And3();
			wait ();
		}else if(sequenceNumber == 3){
			fire2And4();
			wait ();
		}else if(sequenceNumber == 4 || sequenceNumber == 7){
			initiateSpinScenario();
		}else if(sequenceNumber == 5){
			initiateBackAndForthIntersectingScenario();
		}else if(sequenceNumber == 6){
			initiateBackAndForthPairsScenario();
		}
	}

	public void initiateSpinScenario(){
		StartCoroutine(SpinClockwiseCo());                
	}
	
	private IEnumerator SpinClockwiseCo(){
		bool isContinuing = true;
		bool isFiringClockwise;

		float sequenceNumber = random.Next (1, 3);
		if(sequenceNumber == 1){
			isFiringClockwise = true;
		}else{
			isFiringClockwise = false;
		}

		float sequenceNumber2 = random.Next (1, 5);
		while(sequenceNumber2 < 5){

			if(isFiringClockwise){
				fire2And4();
				Debug.Log ("isFiringClockwise");
			}else{
				fire1And3();
				Debug.Log ("isFiringCOUNTERClockwise");
			}

			yield return new WaitForSeconds (waitTime); 
			sequenceNumber2 ++;
		}
		fireRandomSequence(); 
	}

	public void initiateBackAndForthIntersectingScenario(){
		StartCoroutine(BackAndForthIntersectingCo());                
	}
	
	private IEnumerator BackAndForthIntersectingCo(){
		float sequenceNumber2 = random.Next (1, 3);
		while(sequenceNumber2 < 3){
			Debug.Log ("BackAndForthIntersectingCo");
			fire1And3();
			yield return new WaitForSeconds (waitTime); 
			fire2And4();
			yield return new WaitForSeconds (waitTime);
			sequenceNumber2 ++;
		}
		fireRandomSequence();
	} 

	public void initiateBackAndForthPairsScenario(){
		StartCoroutine(BackAndForthPairsCo());                
	}
	
	private IEnumerator BackAndForthPairsCo(){
		float sequenceNumber2 = random.Next (1, 3);
		while(sequenceNumber2 < 3){
			Debug.Log ("initiateBackAndForthPairsScenario");
			fire1And2();
			yield return new WaitForSeconds (waitTime); 
			fire3And4();
			yield return new WaitForSeconds (waitTime);
			sequenceNumber2 ++;
		}
		fireRandomSequence();
	} 

	//SPEED STUFF
	public void waitForFirstSpeedChange(){
		StartCoroutine(waitForFirstSpeedChangeCo());                
	}
	
	private IEnumerator waitForFirstSpeedChangeCo(){
		//Dont do shit
		if(hasWaitedForFirstSpeedChange == false){
			hasWaitedForFirstSpeedChange = true;
			canFire = false;
			yield return new WaitForSeconds (2); 
			canFire = true;
			line.spinningSpeed = GameManager.Instance.lineSpinningSpeed2;  
			//new addition
			projectile.Speed = GameManager.Instance.projectileSpeed2;
			projectile2.Speed = GameManager.Instance.projectileSpeed2; 
			waitTime = GameManager.Instance.firstWaitTime2;
			waitTime2 = GameManager.Instance.secondWaitTime2; 
		}
	}
	
	public void waitForSecondSpeedChange(){
		StartCoroutine(waitForSecondSpeedChangeCo());                
	}
	
	private IEnumerator waitForSecondSpeedChangeCo(){
		//Dont do shit
		if(hasWaitedForSecondSpeedChange == false){
			hasWaitedForSecondSpeedChange = true;
			canFire = false;
			yield return new WaitForSeconds (2); 
			canFire = true;
			line.spinningSpeed = GameManager.Instance.lineSpinningSpeed3;   
			//
			projectile.Speed = GameManager.Instance.projectileSpeed3;
			projectile2.Speed = GameManager.Instance.projectileSpeed3; 
			waitTime = GameManager.Instance.firstWaitTime3;
			waitTime2 = GameManager.Instance.secondWaitTime3;
		}
	}
	
	public void waitForThirdSpeedChange(){
		StartCoroutine(waitForThirdSpeedChangeCo());                
	}
	
	private IEnumerator waitForThirdSpeedChangeCo(){
		if(hasWaitedForThirdSpeedChange == false){
			hasWaitedForThirdSpeedChange = true;
			canFire = false;
			yield return new WaitForSeconds (2); 
			canFire = true;
			line.spinningSpeed = GameManager.Instance.lineSpinningSpeed4; 
			//
			projectile.Speed = GameManager.Instance.projectileSpeed4;
			projectile2.Speed = GameManager.Instance.projectileSpeed4; 
			waitTime = GameManager.Instance.firstWaitTime4;
			waitTime2 = GameManager.Instance.secondWaitTime4; 
		}
	}

	public void waitForFourthSpeedChange(){
		StartCoroutine(waitForFourthSpeedChangeCo());                
	}
	
	private IEnumerator waitForFourthSpeedChangeCo(){
		if(hasWaitedForFourthSpeedChange == false){
			hasWaitedForFourthSpeedChange = true;
			canFire = false;
			yield return new WaitForSeconds (2); 
			canFire = true;
			line.spinningSpeed = GameManager.Instance.lineSpinningSpeed5; 
			//
			projectile.Speed = GameManager.Instance.projectileSpeed5;
			projectile2.Speed = GameManager.Instance.projectileSpeed5; 
			waitTime = GameManager.Instance.firstWaitTime5;
		}
	}

	public void waitForFifthSpeedChange(){
		StartCoroutine(waitForFifthSpeedChangeCo());                
	}
	
	private IEnumerator waitForFifthSpeedChangeCo(){
		if(hasWaitedForFifthSpeedChange == false){
			hasWaitedForFifthSpeedChange = true;
			canFire = false;
			yield return new WaitForSeconds (2); 
			canFire = true;
			line.spinningSpeed = GameManager.Instance.lineSpinningSpeed6; 
			//
			projectile.Speed = GameManager.Instance.projectileSpeed6;
			projectile2.Speed = GameManager.Instance.projectileSpeed6; 
			waitTime = GameManager.Instance.firstWaitTime6;
		}
	}

	public void waitForSixthSpeedChange(){
		StartCoroutine(waitForSixthSpeedChangeCo());                
	}
	
	private IEnumerator waitForSixthSpeedChangeCo(){
		if(hasWaitedForSixthSpeedChange == false){
			hasWaitedForSixthSpeedChange = true;
			canFire = false;
			yield return new WaitForSeconds (2); 
			canFire = true;
			line.spinningSpeed = GameManager.Instance.lineSpinningSpeed7; 
			projectile.Speed = GameManager.Instance.projectileSpeed7;
			projectile2.Speed = GameManager.Instance.projectileSpeed7; 
			waitTime = GameManager.Instance.firstWaitTime7;
		}
	}

	public void waitForSeventhSpeedChange(){
		StartCoroutine(waitForSeventhSpeedChangeCo());                
	}
	
	private IEnumerator waitForSeventhSpeedChangeCo(){
		if(hasWaitedForSeventhSpeedChange == false){
			hasWaitedForSeventhSpeedChange = true;
			canFire = false;
			yield return new WaitForSeconds (2); 
			canFire = true;
			line.spinningSpeed = GameManager.Instance.lineSpinningSpeed8; 
			//
			projectile.Speed = GameManager.Instance.projectileSpeed8;
			projectile2.Speed = GameManager.Instance.projectileSpeed8; 
			waitTime = GameManager.Instance.firstWaitTime8;
		}
	}

	public void waitForEighthSpeedChange(){
		StartCoroutine(waitForEighthSpeedChangeCo());                
	}
	
	private IEnumerator waitForEighthSpeedChangeCo(){
		if(hasWaitedForEighthSpeedChange == false){
			hasWaitedForEighthSpeedChange = true;
			canFire = false;
			yield return new WaitForSeconds (2); 
			canFire = true;
			line.spinningSpeed = GameManager.Instance.lineSpinningSpeed9; 
			//
			projectile.Speed = GameManager.Instance.projectileSpeed9;
			projectile2.Speed = GameManager.Instance.projectileSpeed9; 
			waitTime = GameManager.Instance.firstWaitTime9;
		}
	}

	public void waitForNinthSpeedChange(){
		StartCoroutine(waitForNinthSpeedChangeCo());                
	}
	
	private IEnumerator waitForNinthSpeedChangeCo(){
		if(hasWaitedForNinthSpeedChange == false){
			hasWaitedForNinthSpeedChange = true;
			canFire = false;
			yield return new WaitForSeconds (2); 
			canFire = true;
			line.spinningSpeed = GameManager.Instance.lineSpinningSpeed10; 
			//
			projectile.Speed = GameManager.Instance.projectileSpeed10;
			projectile2.Speed = GameManager.Instance.projectileSpeed10; 
			waitTime = GameManager.Instance.firstWaitTime10;
		}
	}
	
	public void determineSpeeds(){
		if(RunningTime.TotalSeconds >= 0 && RunningTime.TotalSeconds < 10){  
			projectile.Speed = GameManager.Instance.projectileSpeed1;
			projectile2.Speed = GameManager.Instance.projectileSpeed1; 
			waitTime = GameManager.Instance.firstWaitTime1;
			waitTime2 = GameManager.Instance.secondWaitTime1;
			line.spinningSpeed = GameManager.Instance.lineSpinningSpeed1;  
			hasWaitedForFirstSpeedChange = false; 
		}
		else if(RunningTime.TotalSeconds >= 10 && RunningTime.TotalSeconds < 20){  
			waitForFirstSpeedChange();
		}
		else if(RunningTime.TotalSeconds >= 20 && RunningTime.TotalSeconds < 30){  
			waitForSecondSpeedChange();
		}
		else if(RunningTime.TotalSeconds >= 30 && RunningTime.TotalSeconds < 40){  
			waitForThirdSpeedChange();
		}
		else if(RunningTime.TotalSeconds >= 40 && RunningTime.TotalSeconds < 50){  
			waitForFourthSpeedChange();
		}
		else if(RunningTime.TotalSeconds >= 50 && RunningTime.TotalSeconds < 60){  
			waitForFifthSpeedChange();
		}
		else if(RunningTime.TotalSeconds >= 50 && RunningTime.TotalSeconds < 60){  
			waitForSixthSpeedChange();
		}
		else if(RunningTime.TotalSeconds >= 60){  
			waitForSeventhSpeedChange();
		}
//		else if(RunningTime.TotalSeconds >= 120 && RunningTime.TotalSeconds < 135){  
//			waitForEighthSpeedChange();
//		}
//		else if(RunningTime.TotalSeconds >= 135){  
//			waitForNinthSpeedChange();
//		}
	}
	
	public void wait(){
		StartCoroutine(waitCo());                
	}
	
	private IEnumerator waitCo(){
		yield return new WaitForSeconds (waitTime); 
		fireRandomSequence();
	}
}
