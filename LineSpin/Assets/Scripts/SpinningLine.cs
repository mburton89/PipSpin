using UnityEngine;
using System.Collections;

public class SpinningLine : MonoBehaviour {

	public Animator Animator; 
	public AudioClip Bass;
	public AudioClip Snare;
	public int spinningSpeed;
	public bool canSpin;
	
	void Start () {
		canSpin = true;
	}

	void Update () {
		if(canSpin){
			HandleKeyboard();
			HandleUserTouches();
		}
	}

	public void HandleKeyboard(){
		if (Input.GetKey(KeyCode.LeftArrow)) {
			spinLineCounterClockwise();
		} else if (Input.GetKey (KeyCode.RightArrow)) {
			spinLineClockwise();
		}
	} 

	public void HandleUserTouches(){
		for (int i = 0; i < Input.touchCount; i++){  
			Touch touch = Input.GetTouch(i);
			if (touch.phase >= TouchPhase.Began){ //&& touch.tapCount == 1){
				Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);  
				if(touchPosition.x < 0){
					spinLineCounterClockwise();    
				}else if(touchPosition.x > 0){
					spinLineClockwise();    
				}
			}
		}
	}

	public void spinLineClockwise(){
//		AudioSource.PlayClipAtPoint(Snare, transform.position);
//		if(Animator.GetCurrentAnimatorStateInfo(0).IsName("VIdle")){
//			Animator.SetTrigger("VR"); 
//		}else if(Animator.GetCurrentAnimatorStateInfo(0).IsName("HIdle")){
//			Animator.SetTrigger("HR"); 
//		}

		transform.Rotate(0, 0, -spinningSpeed* Time.deltaTime,Space.Self);    
	}
	       
	public void spinLineCounterClockwise(){
//		AudioSource.PlayClipAtPoint(Snare, transform.position);
//		if(Animator.GetCurrentAnimatorStateInfo(0).IsName("VIdle")){
//			Animator.SetTrigger("VL"); 
//		}else if(Animator.GetCurrentAnimatorStateInfo(0).IsName("HIdle")){
//			Animator.SetTrigger("HL"); 
//		}
		transform.Rotate(0, 0, spinningSpeed * Time.deltaTime,Space.Self); 
	}

	public void turnWhite(){
		GetComponent<SpriteRenderer>().color = Color.white;
	}

	public void turnPurple(){
		//GetComponent<SpriteRenderer>().color = new Color(.7f, 0.0f, 0.8f, 1); 
	}

	public void turnBlue(){
		GetComponent<SpriteRenderer>().color = Color.blue; 
	}

	public void turnGreen(){
		GetComponent<SpriteRenderer>().color = Color.green; 
	}

	public void turnYellow(){
		GetComponent<SpriteRenderer>().color = Color.yellow; 
	}

	public void turnOrange(){
		GetComponent<SpriteRenderer>().color = new Color(1, 0.5f, 0.0f, 1);
	}

	public void turnRed(){
		GetComponent<SpriteRenderer>().color = Color.red; 
	}

	public void turnBlack(){
		GetComponent<SpriteRenderer>().color = Color.black; 
	}
}
