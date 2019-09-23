using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Projectile : MonoBehaviour, ITakeDamage{
	
	//public GameObject fastPaddle;
	public GameObject Owner { get; private set;}
	public Vector2 Direction { get; set;}
	public Vector2 Velocity { get; private set;}
	public LayerMask CollisionMask;
	//public ProjectileDispenser projectileDispenser;
	public Background background;
	public GameManager gameManager;
	//public FiringPatterns patterns;
	public SpinningLine line;
	//private static System.Random random = new System.Random();
	
	public float Speed;
	public float timeToLive;
	public int damage;
	public int pointsToGiveToPlayer;
	public bool isActive {get; set;}
	public bool isDeflected{get; set;}

	public AudioClip GameOverSound;
	
	public void Awake(){

	}
	
	public void Start () {
//		projectileDispenser = FindObjectOfType<ProjectileDispenser> ();
//		patterns = FindObjectOfType<FiringPatterns> ();
		line = FindObjectOfType<SpinningLine> ();
		background = FindObjectOfType<Background> ();
		gameManager = FindObjectOfType<GameManager> ();    
		isActive = true;
		//transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z + 45 , transform.rotation.w);
	}
	
	void Update () {

		if(transform.position.y < -11){
			ResetGame();
			return;
		}
				
		transform.Translate ((Direction + new Vector2 (Velocity.x, Velocity.y)) * Speed * Time.deltaTime, Space.World);
		isActive = true;
	}
	
	public void TakeDamage(int damage, GameObject instigator){
		destroyProjectile ();
	}
	
	public void Initialize(GameObject owner, Vector2 direction, Vector2 velocity){
		transform.up = direction;
		Owner = owner;
		Direction = direction; 
		Velocity = velocity;  
		OnInitialized();
		//transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, transform.rotation.z + 45 , transform.rotation.w);
		   
	}
	
	protected virtual void OnInitialized(){
		return;
	}
	
	public virtual void OnTriggerEnter2D(Collider2D other){
		
		if((CollisionMask.value & (1 << other.gameObject.layer)) == 0){
			OnNotCollideWith(other);
			return;
		}
		OnCollideOther(other);
	}
	
	protected virtual void OnNotCollideWith(Collider2D other){
		if(other.name == "Line"){
			//gameManager.determineMode();
			  
			//endSession(); 
			line.canSpin = false;      
			Speed = 0;    
			//Destroy(gameObject);  
			other.GetComponent<SpriteRenderer>().sprite = (Sprite)Resources.Load ("Line2White", typeof(Sprite)) as Sprite;
			gameManager.displayGameOverScreen();    
			//projectileDispenser.activeProjectiles --;
//			if(projectileDispenser.activeProjectiles == 0){    
//				//projectileDispenser.fireRandomSequence();     
//			}
		}
	}
	
	protected virtual void OnCollideOwner(Collider2D other, ITakeDamage takeDamage){
		//Debug.Log ("LOSERWWW");
	}
	
	protected virtual void OnCollideTakeDamage(Collider2D other, ITakeDamage takeDamage){

		destroyProjectile();
		//Debug.Log ("LOSERTTT");
	}
	
	public void OnCollideOther(Collider2D other){      
		 
//		GameManager.Instance.displayGameOverScreen();
		//endSession();  
	} 
	
	private void destroyProjectile(){
		GameManager.Instance.AddPoints(1);
		Destroy(gameObject);
		//projectileDispenser.activeProjectiles --;
//		if(projectileDispenser.activeProjectiles == 0){
//			//patterns.fireRedSequence();
//		}
//		Debug.Log(GameManager.Instance.Points);    
	}
	
	private void ResetGame(){
		destroyProjectile();
		isActive = false;
	}

	private void endSession(){
		AudioSource.PlayClipAtPoint(GameOverSound, transform.position);
		GameManager.Instance.ResetPointsToZero();
	}


}