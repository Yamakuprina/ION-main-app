﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SwipeDirection {
	None = 0,
	Left = 1,
	Right = 2,
}

public class SwipeManager : MonoBehaviour {
	private static SwipeManager instance;
	private static SwipeManager Instance{get{return instance;}}

	private float opener = 0;
	public GameObject SideBar;
	private Animator Anim;


	public SwipeDirection Direction{ set; get;}
	private Vector3 touchPosition;
	public float SwipeResistanceX;

	private void Start(){
		instance = this;
		Anim = SideBar.GetComponent<Animator>();
	}
		
	private void Update ()
	{
		
		Direction = SwipeDirection.None;

		if (Input.GetMouseButtonDown (0)) {
			touchPosition = Input.mousePosition;
		}

		if (opener == 1) {
			Anim.SetBool ("SideOn", true);
			Anim.SetBool ("SideOff", false);



		} 
		if (Direction == SwipeDirection.Left) {
			Anim.SetBool ("SideOff", true);
			if (opener > 0) {
				opener--;}
			Anim.SetBool ("SideOn", false);
		}
		if (Input.GetMouseButtonUp (0)) {
			Vector2 deltaSwipe = touchPosition - Input.mousePosition;
			if (Mathf.Abs (deltaSwipe.x) > SwipeResistanceX) {
				//Свайп здесь начался на X
				Direction |= (deltaSwipe.x < 0) ? SwipeDirection.Right : SwipeDirection.Left;
				if (Direction == SwipeDirection.Right) {
					Anim.SetBool ("SideOn", true);
					Anim.SetBool ("SideOff", false);



				} 
				if (Direction == SwipeDirection.Left) {
					Anim.SetBool ("SideOff", true);
					if (opener > 0) {
						opener--;
					}
					Anim.SetBool ("SideOn", false);

				}
		
			}
		}
	}

	public void Opener(){
		if (opener == 0) {
			opener++;
		}
	}

}

