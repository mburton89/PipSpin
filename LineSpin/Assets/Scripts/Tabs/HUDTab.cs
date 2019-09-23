using UnityEngine;
using System.Collections;

public class HUDTab : MonoBehaviour {

	public Animator Animator; 
	
	void Start () {

	}

	void Update () {
	
	}

	public void lowerUpperTab(){
		Animator.SetTrigger("TabGoDown"); 

//		Animator.SetTrigger("LeftTabGoRight");
//		Animator.SetTrigger("RightTabGoLeft");
//		Debug.Log("STUFFFFF");    
	}    

	public void raiseUpperTab(){
//		Animator.ResetTrigger("TabGoDown"); 
		Animator.SetTrigger("TabGoUp");
//		Animator.SetTrigger("LeftTabGoLeft");
//		Animator.SetTrigger("RightTabGoRight");
	}
}
