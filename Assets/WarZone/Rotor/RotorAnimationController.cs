using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RotorAnimationController : MonoBehaviour {


	public	Text	DebugText;

	Animator	mANI;

	// Use this for initialization
	void Start () {
		mANI = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		mANI.SetBool ("Running", (InputController.GetInput (InputController.Directions.Thrust) > 0f));      //Set flag to tell animator to start rotor
	}
}
